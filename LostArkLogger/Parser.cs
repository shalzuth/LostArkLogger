using K4os.Compression.LZ4;
using LostArkLogger.Utilities;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace LostArkLogger
{
    internal class Parser : IDisposable
    {
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
        [DllImport("wpcap.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)] static extern IntPtr pcap_strerror(int err);
#pragma warning restore CA2101 // Specify marshaling for P/Invoke string arguments
        Machina.TCPNetworkMonitor tcp;
        ILiveDevice pcap;
        public event Action<LogInfo> onCombatEvent;
        public event Action onNewZone;
        public event Action beforeNewZone;
        public event Action<int> onPacketTotalCount;
        public bool use_npcap = false;
        private object lockPacketProcessing = new object(); // needed to synchronize UI swapping devices
        public Machina.Infrastructure.NetworkMonitorType? monitorType = null;
        public List<Encounter> Encounters = new List<Encounter>();
        public Encounter currentEncounter = new Encounter();
        Byte[] fragmentedPacket = new Byte[0];
        private string _localPlayerName = "You";
        private uint _localGearLevel = 0;
        public bool WasWipe = false;
        public bool WasKill = false;
        public bool DisplayNames = true;
        public StatusEffectTracker statusEffectTracker;

        public Parser()
        {
            Encounters.Add(currentEncounter);
            onCombatEvent += Parser_onDamageEvent;
            onNewZone += Parser_onNewZone;
            statusEffectTracker = new StatusEffectTracker(this);
            statusEffectTracker.OnStatusEffectEnded += Parser_onStatusEffectEnded;
            statusEffectTracker.OnStatusEffectStarted += StatusEffectTracker_OnStatusEffectStarted; ;
            InstallListener();
        }

        // UI needs to be able to ask us to reload our listener based on the current user settings
        public void InstallListener()
        {
            lock (lockPacketProcessing)
            {
                // If we have an installed listener, that needs to go away or we duplicate traffic
                UninstallListeners();

                // Reset all state related to current packet processing here that won't be valid when creating a new listener.
                fragmentedPacket = new Byte[0];

                // We default to using npcap, but the UI can also set this to false.
                if (use_npcap)
                {
                    monitorType = Machina.Infrastructure.NetworkMonitorType.WinPCap;
                    string filter = "ip and tcp port 6040";
                    bool foundAdapter = false;
                    NetworkInterface gameInterface;
                    // listening on every device results in duplicate traffic, unfortunately, so we'll find the adapter used by the game here
                    try
                    {
                        pcap_strerror(1); // verify winpcap works at all
                        gameInterface = NetworkUtil.GetAdapterUsedByProcess("LostArk");
                        foreach (var device in CaptureDeviceList.Instance)
                        {
                            if (device.MacAddress == null) continue; // SharpPcap.IPCapDevice.MacAddress is null in some cases
                            if (gameInterface.GetPhysicalAddress().ToString() == device.MacAddress.ToString())
                            {
                                try
                                {
                                    device.Open(DeviceModes.None, 1000); // todo: 1sec timeout ok?
                                    device.Filter = filter;
                                    device.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival_pcap);
                                    device.StartCapture();
                                    pcap = device;
                                    foundAdapter = true;
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    var exceptionMessage = "Exception while trying to listen to NIC " + device.Name + "\n" + ex.ToString();
                                    Console.WriteLine(exceptionMessage);
                                    Logger.AppendLog(254, exceptionMessage);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var exceptionMessage = "Sharppcap init failed, using rawsockets instead, exception:\n" + ex.ToString();
                        Console.WriteLine(exceptionMessage);
                        Logger.AppendLog(254, exceptionMessage);
                    }
                    // If we failed to find a pcap device, fall back to rawsockets.
                    if (!foundAdapter)
                    {
                        use_npcap = false;
                        pcap = null;
                    }
                }

                if (use_npcap == false)
                {
                    // Always fall back to rawsockets
                    tcp = new Machina.TCPNetworkMonitor();
                    tcp.Config.WindowClass = "EFLaunchUnrealUWindowsClient";
                    monitorType = tcp.Config.MonitorType = Machina.Infrastructure.NetworkMonitorType.RawSocket;
                    tcp.DataReceivedEventHandler += (Machina.Infrastructure.TCPConnection connection, byte[] data) => Device_OnPacketArrival_machina(connection, data);
                    tcp.Start();
                }
            }
        }

        void ProcessDamageEvent(Entity sourceEntity, UInt32 skillId, UInt32 skillEffectId, SkillDamageEvent dmgEvent)
        {
            var hitFlag = (HitFlag)(dmgEvent.Modifier & 0xf);
            if (hitFlag == HitFlag.HIT_FLAG_DAMAGE_SHARE && skillId == 0 && skillEffectId == 0)
                return;
            var hitOption = (HitOption)(((dmgEvent.Modifier >> 4) & 0x7) - 1);
            var skillName = Skill.GetSkillName(skillId, skillEffectId);
            var targetEntity = currentEncounter.Entities.GetOrAdd(dmgEvent.TargetId);
            var destinationName = targetEntity != null ? targetEntity.VisibleName : dmgEvent.TargetId.ToString("X");
            //var log = new LogInfo { Time = DateTime.Now, Source = sourceName, PC = sourceName.Contains("("), Destination = destinationName, SkillName = skillName, Crit = (dmgEvent.FlagsMaybe & 0x81) > 0, BackAttack = (dmgEvent.FlagsMaybe & 0x10) > 0, FrontAttack = (dmgEvent.FlagsMaybe & 0x20) > 0 };
            var log = new LogInfo
            {
                Time = DateTime.Now,
                SourceEntity = sourceEntity,
                DestinationEntity = targetEntity,
                SkillId = skillId,
                SkillEffectId = skillEffectId,
                SkillName = skillName,
                Damage = (ulong)dmgEvent.Damage,
                Crit = hitFlag == HitFlag.HIT_FLAG_CRITICAL || hitFlag == HitFlag.HIT_FLAG_DOT_CRITICAL,
                BackAttack = hitOption == HitOption.HIT_OPTION_BACK_ATTACK,
                FrontAttack = hitOption == HitOption.HIT_OPTION_FRONTAL_ATTACK
            };
            onCombatEvent?.Invoke(log);
            currentEncounter.RaidInfos.Add(log);
            Logger.AppendLog(8, sourceEntity.EntityId.ToString("X"), sourceEntity.Name, skillId.ToString(), Skill.GetSkillName(skillId), skillEffectId.ToString(), Skill.GetSkillEffectName(skillEffectId), targetEntity.EntityId.ToString("X"), targetEntity.Name, dmgEvent.Damage.ToString(), dmgEvent.Modifier.ToString("X"), dmgEvent.CurHp.ToString(), dmgEvent.MaxHp.ToString());
        }
        void ProcessSkillDamage(PKTSkillDamageNotify damage)
        {
            var sourceEntity = GetSourceEntity(damage.SourceId);
            var className = Skill.GetClassFromSkill(damage.SkillId);
            if (String.IsNullOrEmpty(sourceEntity.ClassName) && className != "UnknownClass")
            {
                sourceEntity.Type = Entity.EntityType.Player;
                sourceEntity.ClassName = className; // for case where we don't know user's class yet            
            }

            if (String.IsNullOrEmpty(sourceEntity.Name)) sourceEntity.Name = damage.SourceId.ToString("X");
            foreach (var dmgEvent in damage.skillDamageEvents)
                ProcessDamageEvent(sourceEntity, damage.SkillId, damage.SkillEffectId, dmgEvent);
        }

        void ProcessSkillDamage(PKTSkillDamageAbnormalMoveNotify damage)
        {
            var sourceEntity = GetSourceEntity(damage.SourceId);
            var className = Skill.GetClassFromSkill(damage.SkillId);
            if (String.IsNullOrEmpty(sourceEntity.ClassName) && className != "UnknownClass")
            {
                sourceEntity.Type = Entity.EntityType.Player;
                sourceEntity.ClassName = className; // for case where we don't know user's class yet            
            }

            if (String.IsNullOrEmpty(sourceEntity.Name)) sourceEntity.Name = damage.SourceId.ToString("X");
            foreach (var dmgEvent in damage.skillDamageMoveEvents)
                ProcessDamageEvent(sourceEntity, damage.SkillId, damage.SkillEffectId, dmgEvent.skillDamageEvent);
        }

        OpCodes GetOpCode(Byte[] packets)
        {
            var opcodeVal = BitConverter.ToUInt16(packets, 2);
            var opCodeString = "";
            if (Properties.Settings.Default.Region == Region.Steam) opCodeString = ((OpCodes_Steam)opcodeVal).ToString();
            //if (Properties.Settings.Default.Region == Region.Russia) opCodeString = ((OpCodes_ru)opcodeVal).ToString();
            if (Properties.Settings.Default.Region == Region.Korea) opCodeString = ((OpCodes_Korea)opcodeVal).ToString();
            return (OpCodes)Enum.Parse(typeof(OpCodes), opCodeString);
        }
        Byte[] XorTableSteam = ObjectSerialize.Decompress(Properties.Resources.xor_Steam);
        //Byte[] XorTableRu = ObjectSerialize.Decompress(Properties.Resources.xor_ru);
        Byte[] XorTableKorea = ObjectSerialize.Decompress(Properties.Resources.xor_Korea);
        Byte[] XorTable { get { return Properties.Settings.Default.Region == Region.Steam ? XorTableSteam : XorTableKorea; } }
        void ProcessPacket(List<Byte> data)
        {
            var packets = data.ToArray();
            var packetWithTimestamp = BitConverter.GetBytes(DateTime.UtcNow.ToBinary()).ToArray().Concat(data);
            onPacketTotalCount?.Invoke(loggedPacketCount++);
            while (packets.Length > 0)
            {
                if (fragmentedPacket.Length > 0)
                {
                    packets = fragmentedPacket.Concat(packets).ToArray();
                    fragmentedPacket = new Byte[0];
                }
                if (6 > packets.Length)
                {
                    fragmentedPacket = packets.ToArray();
                    return;
                }
                var opcode = GetOpCode(packets);
                //Console.WriteLine(opcode);
                var packetSize = BitConverter.ToUInt16(packets.ToArray(), 0);
                if (packets[5] != 1 || 6 > packets.Length || packetSize < 7)
                {
                    // not sure when this happens
                    fragmentedPacket = new Byte[0];
                    return;
                }
                if (packetSize > packets.Length)
                {
                    fragmentedPacket = packets;
                    return;
                }
                var payload = packets.Skip(6).Take(packetSize - 6).ToArray();
                Xor.Cipher(payload, BitConverter.ToUInt16(packets, 2), XorTable);
                switch (packets[4])
                {
                    case 0: //None
                        payload = payload.Skip(16).ToArray();
                        break;
                    case 1: //LZ4
                        var buffer = new byte[0x11ff2];
                        var result = LZ4Codec.Decode(payload, 0, payload.Length, buffer, 0, 0x11ff2);
                        if (result < 1) throw new Exception("LZ4 output buffer too small");
                        payload = buffer.Take(result).Skip(16).ToArray();
                        break;
                    case 2: //Snappy
                        //https://github.com/robertvazan/snappy.net
                        payload = Snappy.SnappyCodec.Uncompress(payload.ToArray()).Skip(16).ToArray();
                        //payload = SnappyCodec.Uncompress(payload.Skip(Properties.Settings.Default.Region == Region.Russia ? 4 : 0).ToArray()).Skip(16).ToArray();
                        break;
                    case 3: //Oodle
                        payload = Oodle.Decompress(payload).Skip(16).ToArray();
                        break;
                    default:
                        payload = payload.Skip(16).ToArray();
                        break;
                }

                // write packets for analyzing, bypass common, useless packets
                // if (opcode != OpCodes.PKTMoveError && opcode != OpCodes.PKTMoveNotify && opcode != OpCodes.PKTMoveNotifyList && opcode != OpCodes.PKTTransitStateNotify && opcode != OpCodes.PKTPing && opcode != OpCodes.PKTPong)
                //    Console.WriteLine(opcode + " : " + opcode.ToString("X") + " : " + BitConverter.ToString(payload));

                /* Uncomment for auction house accessory sniffing
                if (opcode == OpCodes.PKTAuctionSearchResult)
                {
                    var pc = new PKTAuctionSearchResult(payload);
                    Console.WriteLine("NumItems=" + pc.NumItems.ToString());
                    Console.WriteLine("Id, Stat1, Stat2, Engraving1, Engraving2, Engraving3");
                    foreach (var item in pc.Items)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                */
                if (opcode == OpCodes.PKTTriggerStartNotify)
                {
                    var trigger = new PKTTriggerStartNotify(new BitReader(payload));
                    if (trigger.Signal >= (int)TriggerSignalType.DUNGEON_PHASE1_CLEAR && trigger.Signal <= (int)TriggerSignalType.DUNGEON_PHASE4_FAIL) // if in range of dungeon fail/kill
                    {
                        if (((TriggerSignalType)trigger.Signal).ToString().Contains("FAIL")) // not as good performance, but more clear and in case enums change order in future
                        {
                            WasWipe = true;
                            WasKill = false;
                        }
                        else
                        {
                            WasKill = true;
                            WasWipe = false;
                        }
                    }
                }
                if (opcode == OpCodes.PKTNewProjectile)
                {
                    var projectile = new PKTNewProjectile(new BitReader(payload)).projectileInfo;
                    currentEncounter.Entities.AddOrUpdate(new Entity
                    {
                        OwnerId = projectile.OwnerId,
                        EntityId = projectile.ProjectileId,
                        Type = Entity.EntityType.Projectile
                    });
                    var battleitem = BattleItem.IsBattleItem(projectile.SkillId, "projectile");
                    if (battleitem)
                    {
                        Entity entity = currentEncounter.Entities.GetOrAdd(projectile.OwnerId);
                        var log = new LogInfo
                        {
                            Time = DateTime.Now,
                            SourceEntity = entity,
                            DestinationEntity = entity, //projectiles don't have destination, but can't be null causes exception getting encounter name
                            SkillName = BattleItem.GetBattleItemName(projectile.SkillId),
                            SkillId = projectile.SkillId,
                            BattleItem = battleitem
                        };
                        currentEncounter.Infos.Add(log);
                        Logger.AppendLog(15, projectile.OwnerId.ToString("X"), entity.Name, projectile.SkillId.ToString(), BattleItem.GetBattleItemName(projectile.SkillId));
                    }
                }
                else if (opcode == OpCodes.PKTInitEnv)
                {
                    var env = new PKTInitEnv(new BitReader(payload));
                    beforeNewZone?.Invoke();
                    if (currentEncounter.Infos.Count <= 50) Encounters.Remove(currentEncounter);
                    else currentEncounter.End = DateTime.Now;

                    currentEncounter = new Encounter();
                    Encounters.Add(currentEncounter);
                    var temp = new Entity
                    {
                        EntityId = env.PlayerId,
                        Name = _localPlayerName,
                        Type = Entity.EntityType.Player,
                        GearLevel = _localGearLevel
                    };
                    currentEncounter.Entities.AddOrUpdate(temp);

                    onNewZone?.Invoke();
                    Logger.AppendLog(1, env.PlayerId.ToString("X"));
                }
                else if (opcode == OpCodes.PKTRaidBossKillNotify //Packet sent for boss kill, wipe or start
                         || opcode == OpCodes.PKTTriggerBossBattleStatus
                         || opcode == OpCodes.PKTRaidResult)
                {
                    var Duration = Convert.ToUInt64(DateTime.Now.Subtract(currentEncounter.Start).TotalSeconds);
                    currentEncounter.End = DateTime.Now;
                    Task.Run(async() =>
                    {
                        
                        if (WasKill || WasWipe || opcode == OpCodes.PKTRaidBossKillNotify || opcode == OpCodes.PKTRaidResult) // if kill or wipe update the raid time duration 
                        {
                            await Task.Delay(12000);
                            currentEncounter.RaidTime += Duration;
                            foreach (var i in currentEncounter.Entities.Where(e => e.Value.Type == Entity.EntityType.Player))
                            {
                                if (!(i.Value.dead)) // if Player not dead on end of kill write fake death logInfo to track their time alive
                                {
                                    var log = new LogInfo
                                    {
                                        Time = DateTime.Now,
                                        SourceEntity = i.Value,
                                        DestinationEntity = i.Value,
                                        SkillName = "Death",
                                        TimeAlive = Duration,
                                        Death = true
                                    };
                                    currentEncounter.RaidInfos.Add(log);
                                    currentEncounter.Infos.Add(log);

                                }
                                else // reset death flag on every wipe or kill
                                {
                                    i.Value.dead = false;
                                }
                            }
                            
                        }
                        
                        //Task.Delay(100); // wait 4000ms to capture any final damage/status Effect packets
                        currentEncounter = new Encounter();
                        currentEncounter.Entities = Encounters.Last().Entities; // preserve entities
                        if (WasWipe || Encounters.Last().AfterWipe)
                        {

                            currentEncounter.RaidInfos = Encounters.Last().RaidInfos;
                            currentEncounter.AfterWipe = true; // flag signifying zone after wipe
                            if (Encounters.Last().AfterWipe)
                            {
                                Duration = 0; // dont add time for zone inbetween pulls for raid time
                                currentEncounter.AfterWipe = false;
                            }
                            currentEncounter.RaidTime = Encounters.Last().RaidTime + Duration;// update raid duration
                            WasWipe = false;

                        }
                        else if (WasKill)
                        {
                            WasKill = false;
                        }

                        if (Encounters.Last().Infos.Count <= 50)
                        {
                            Encounters.Remove(Encounters.Last());
                        }
                        Encounters.Add(currentEncounter);
                        Logger.AppendLog(2);
                    });
                }
                else if (opcode == OpCodes.PKTInitPC)
                {
                    var pc = new PKTInitPC(new BitReader(payload));
                    beforeNewZone?.Invoke();
                    if (currentEncounter.Infos.Count == 0) Encounters.Remove(currentEncounter);
                    currentEncounter = new Encounter();
                    Encounters.Add(currentEncounter);
                    _localPlayerName = DisplayNames ? pc.Name : Npc.GetPcClass(pc.ClassId);
                    _localGearLevel = pc.GearLevel;
                    var tempEntity = new Entity
                    {

                        EntityId = pc.PlayerId,
                        Name = _localPlayerName,
                        ClassName = Npc.GetPcClass(pc.ClassId),
                        Type = Entity.EntityType.Player,
                        GearLevel = _localGearLevel
                    };
                    currentEncounter.Entities.AddOrUpdate(tempEntity);

                    var currentHp = pc.statPair.Value[pc.statPair.StatType.IndexOf((byte)StatType.STAT_TYPE_HP)].ToString();
                    var maxHp = pc.statPair.Value[pc.statPair.StatType.IndexOf((byte)StatType.STAT_TYPE_MAX_HP)].ToString();

                    Logger.AppendLog(3, pc.PlayerId.ToString("X"), pc.Name, pc.ClassId.ToString(), Npc.GetPcClass(pc.ClassId), pc.Level.ToString(), tempEntity.GearScore, currentHp, maxHp);
                    statusEffectTracker.InitPc(pc);
                    onNewZone?.Invoke();
                }
                else if (opcode == OpCodes.PKTNewPC)
                {
                    var pcPacket = new PKTNewPC(new BitReader(payload));
                    var pc = pcPacket.pCStruct;
                    var temp = new Entity
                    {
                        EntityId = pc.PlayerId,
                        PartyId = pc.PartyId,
                        Name = DisplayNames ? pc.Name : Npc.GetPcClass(pc.ClassId),
                        ClassName = Npc.GetPcClass(pc.ClassId),
                        Type = Entity.EntityType.Player,
                        GearLevel = pc.GearLevel,
                        dead = false
                    };
                    if (currentEncounter.Entities.ContainsKey(temp.EntityId))
                    {
                        temp.dead = currentEncounter.Entities.GetOrAdd(temp.EntityId).dead;
                    }
                    currentEncounter.Entities.AddOrUpdate(temp);
                    currentEncounter.PartyEntities[temp.PartyId] = temp;

                    var currentHp = pc.statPair.Value[pc.statPair.StatType.IndexOf((byte)StatType.STAT_TYPE_HP)].ToString();
                    var maxHp = pc.statPair.Value[pc.statPair.StatType.IndexOf((byte)StatType.STAT_TYPE_MAX_HP)].ToString();

                    Logger.AppendLog(3, pc.PlayerId.ToString("X"), temp.Name, pc.ClassId.ToString(), Npc.GetPcClass(pc.ClassId), pc.Level.ToString(), temp.GearScore, currentHp, maxHp);
                    statusEffectTracker.NewPc(pcPacket);
                }
                else if (opcode == OpCodes.PKTNewNpc)
                {
                    var npcPacket = new PKTNewNpc(new BitReader(payload));
                    var npc = npcPacket.npcStruct;
                    currentEncounter.Entities.AddOrUpdate(new Entity
                    {
                        EntityId = npc.NpcId,
                        Name = Npc.GetNpcName(npc.NpcType),
                        Type = Entity.EntityType.Npc
                    });
                    Logger.AppendLog(4, npc.NpcId.ToString("X"), npc.NpcType.ToString(), Npc.GetNpcName(npc.NpcType), npc.statPair.Value[npc.statPair.StatType.IndexOf((Byte)StatType.STAT_TYPE_HP)].ToString(), npc.statPair.Value[npc.statPair.StatType.IndexOf((Byte)StatType.STAT_TYPE_MAX_HP)].ToString());
                    statusEffectTracker.NewNpc(npcPacket);
                }
                else if (opcode == OpCodes.PKTRemoveObject)
                {
                    var obj = new PKTRemoveObject(new BitReader(payload));
                    //var projectile = new PKTRemoveObject { Bytes = converted };
                    //ProjectileOwner.Remove(projectile.ProjectileId, projectile.OwnerId);
                }
                else if (opcode == OpCodes.PKTDeathNotify)
                {
                    var death = new PKTDeathNotify(new BitReader(payload));
                    Logger.AppendLog(5, death.TargetId.ToString("X"), currentEncounter.Entities.GetOrAdd(death.TargetId).Name, death.SourceId.ToString("X"), currentEncounter.Entities.GetOrAdd(death.SourceId).Name);
                    DateTime DeathTime = DateTime.Now;
                    TimeSpan timeAlive = DeathTime.Subtract(currentEncounter.Start);
                    if (currentEncounter.Entities.GetOrAdd(death.TargetId).Type == Entity.EntityType.Player) // if death is from player, add death log for time alive tracking
                    {
                        currentEncounter.Entities.GetOrAdd(death.TargetId).dead = true;
                        var log = new LogInfo
                        {
                            Time = DateTime.Now,
                            SourceEntity = currentEncounter.Entities.GetOrAdd(death.TargetId),
                            DestinationEntity = currentEncounter.Entities.GetOrAdd(death.TargetId),
                            SkillName = "Death",
                            TimeAlive = Convert.ToUInt64(timeAlive.TotalSeconds),
                            Death = true
                        };
                        currentEncounter.RaidInfos.Add(log);
                        currentEncounter.Infos.Add(log);
                    }

                    statusEffectTracker.DeathNotify(death);
                }
                else if (opcode == OpCodes.PKTSkillStartNotify)
                {
                    var skill = new PKTSkillStartNotify(new BitReader(payload));
                    Logger.AppendLog(6, skill.SourceId.ToString("X"), currentEncounter.Entities.GetOrAdd(skill.SourceId).Name, skill.SkillId.ToString(), Skill.GetSkillName(skill.SkillId));
                }
                else if (opcode == OpCodes.PKTSkillStageNotify)
                {
                    /*
                       2-stage charge
                        1 start
                        5 if use, 3 if continue
                        8 if use, 4 if continue
                        7 final
                       1-stage charge
                        1 start
                        5 if use, 2 if continue
                        6 final
                       holding whirlwind
                        1 on end
                       holding perfect zone
                        4 on start
                        5 on suc 6 on fail
                    */
                    var skill = new PKTSkillStageNotify(new BitReader(payload));
                    Logger.AppendLog(7, skill.SourceId.ToString("X"), currentEncounter.Entities.GetOrAdd(skill.SourceId).Name, skill.SkillId.ToString(), Skill.GetSkillName(skill.SkillId), skill.Stage.ToString());
                }
                else if (opcode == OpCodes.PKTSkillDamageNotify)
                    ProcessSkillDamage(new PKTSkillDamageNotify(new BitReader(payload)));
                else if (opcode == OpCodes.PKTSkillDamageAbnormalMoveNotify)
                    ProcessSkillDamage(new PKTSkillDamageAbnormalMoveNotify(new BitReader(payload)));
                else if (opcode == OpCodes.PKTStatChangeOriginNotify) // heal
                {
                    var health = new PKTStatChangeOriginNotify(new BitReader(payload));
                    var entity = currentEncounter.Entities.GetOrAdd(health.ObjectId);
                    var log = new LogInfo
                    {
                        Time = DateTime.Now,
                        SourceEntity = entity,
                        DestinationEntity = entity,
                        Heal = (UInt32)health.StatPairChangedList.Value[0]
                    };
                    onCombatEvent?.Invoke(log);
                    // might push this by 1??
                    Logger.AppendLog(9, entity.EntityId.ToString("X"), entity.Name, health.StatPairChangedList.Value[0].ToString(), health.StatPairChangedList.Value[0].ToString());// need to lookup cached max hp??
                }
                else if (opcode == OpCodes.PKTStatusEffectAddNotify) // shields included
                {
                    var statusEffect = new PKTStatusEffectAddNotify(new BitReader(payload));
                    var battleItem = BattleItem.IsBattleItem(statusEffect.statusEffectData.StatusEffectId, "buff");
                    if (battleItem)
                    {
                        var log = new LogInfo
                        {
                            Time = DateTime.Now,
                            SourceEntity = currentEncounter.Entities.GetOrAdd(statusEffect.statusEffectData.SourceId),
                            DestinationEntity = currentEncounter.Entities.GetOrAdd(statusEffect.ObjectId),
                            SkillId = statusEffect.statusEffectData.StatusEffectId,
                            SkillName = BattleItem.GetBattleItemName(statusEffect.statusEffectData.StatusEffectId),
                            BattleItem = battleItem
                        };
                        currentEncounter.Infos.Add(log);
                        Logger.AppendLog(15, statusEffect.statusEffectData.SourceId.ToString("X"), currentEncounter.Entities.GetOrAdd(statusEffect.statusEffectData.SourceId).Name, statusEffect.statusEffectData.StatusEffectId.ToString(), BattleItem.GetBattleItemName(statusEffect.statusEffectData.StatusEffectId));
                    }
                    statusEffectTracker.Add(statusEffect);
                    var amount = statusEffect.statusEffectData.hasValue == 1 ? BitConverter.ToUInt32(statusEffect.statusEffectData.Value, 0) : 0;
                }
                else if (opcode == OpCodes.PKTPartyStatusEffectAddNotify)
                {
                    var partyStatusEffect = new PKTPartyStatusEffectAddNotify(new BitReader(payload));
                    statusEffectTracker.PartyAdd(partyStatusEffect);
                }
                else if (opcode == OpCodes.PKTStatusEffectRemoveNotify)
                {
                    var statusEffectRemove = new PKTStatusEffectRemoveNotify(new BitReader(payload));
                    statusEffectTracker.Remove(statusEffectRemove);

                }
                else if (opcode == OpCodes.PKTPartyStatusEffectRemoveNotify)
                {
                    var partyStatusEffectRemove = new PKTPartyStatusEffectRemoveNotify(new BitReader(payload));
                    statusEffectTracker.PartyRemove(partyStatusEffectRemove);
                }
                /*else if (opcode == OpCodes.PKTParalyzationStateNotify)
                {
                    var stagger = new PKTParalyzationStateNotify(new BitReader(payload));
                    var enemy = currentEncounter.Entities.GetOrAdd(stagger.TargetId);
                    var lastInfo = currentEncounter.Infos.LastOrDefault(); // hope this works
                    if (lastInfo != null) // there's no way to tell what is the source, so drop it for now
                    {
                        var player = lastInfo.SourceEntity;
                        var staggerAmount = stagger.ParalyzationPoint - enemy.Stagger;
                        if (stagger.ParalyzationPoint == 0)
                            staggerAmount = stagger.ParalyzationPointMax - enemy.Stagger;
                        enemy.Stagger = stagger.ParalyzationPoint;
                        var log = new LogInfo
                        {
                            Time = DateTime.Now, SourceEntity = player, DestinationEntity = enemy,
                            SkillName = lastInfo?.SkillName, Stagger = staggerAmount
                        };
                        onCombatEvent?.Invoke(log);
                    }
                }*/
                else if (opcode == OpCodes.PKTCounterAttackNotify)
                {
                    var counter = new PKTCounterAttackNotify(new BitReader(payload));
                    var source = currentEncounter.Entities.GetOrAdd(counter.SourceId);
                    var target = currentEncounter.Entities.GetOrAdd(counter.TargetId);
                    var log = new LogInfo
                    {
                        Time = DateTime.Now,
                        SourceEntity = currentEncounter.Entities.GetOrAdd(counter.SourceId),
                        DestinationEntity = currentEncounter.Entities.GetOrAdd(counter.TargetId),
                        SkillName = "Counter",
                        Damage = 0,
                        Counter = true
                    };
                    onCombatEvent?.Invoke(log);
                    Logger.AppendLog(12, source.EntityId.ToString("X"), source.Name, target.EntityId.ToString("X"), target.Name);
                }
                else if (opcode == OpCodes.PKTNewNpcSummon)
                {
                    var npc = new PKTNewNpcSummon(new BitReader(payload));
                    currentEncounter.Entities.AddOrUpdate(new Entity
                    {
                        EntityId = npc.npcStruct.NpcId,
                        OwnerId = npc.OwnerId,
                        Type = Entity.EntityType.Summon
                    });
                }
                if (packets.Length < packetSize) throw new Exception("bad packet maybe");
                packets = packets.Skip(packetSize).ToArray();
            }
        }

        UInt32 currentIpAddr = 0xdeadbeef;
        int loggedPacketCount = 0;


        void Device_OnPacketArrival_machina(Machina.Infrastructure.TCPConnection connection, byte[] bytes)
        {
            if (tcp == null) return; // To avoid any late delegate calls causing state issues when listener uninstalled
            lock (lockPacketProcessing)
            {
                if (connection.RemotePort != 6040) return;
                var srcAddr = connection.RemoteIP;
                if (srcAddr != currentIpAddr)
                {
                    if (currentIpAddr == 0xdeadbeef || (bytes.Length > 4 && GetOpCode(bytes) == OpCodes.PKTAuthTokenResult && bytes[0] == 0x1e))
                    {
                        beforeNewZone?.Invoke();
                        onNewZone?.Invoke();
                        currentIpAddr = srcAddr;
                    }
                    else return;
                }
                Logger.DoDebugLog(bytes);
                try {
                    ProcessPacket(bytes.ToList());
                } catch (Exception e) {
                    // Console.WriteLine("Failure during processing of packet: " + e);
                }
            }
        }
        void Device_OnPacketArrival_pcap(object sender, PacketCapture evt)
        {
            if (pcap == null) return;
            lock (lockPacketProcessing)
            {
                var rawpkt = evt.GetPacket();
                var packet = PacketDotNet.Packet.ParsePacket(rawpkt.LinkLayerType, rawpkt.Data);
                var ipPacket = packet.Extract<PacketDotNet.IPPacket>();
                var tcpPacket = packet.Extract<PacketDotNet.TcpPacket>();
                var bytes = tcpPacket.PayloadData;

                if (tcpPacket != null)
                {
                    if (tcpPacket.SourcePort != 6040) return;
#pragma warning disable CS0618 // Type or member is obsolete
                    var srcAddr = (uint)ipPacket.SourceAddress.Address;
#pragma warning restore CS0618 // Type or member is obsolete
                    if (srcAddr != currentIpAddr)
                    {
                        if (currentIpAddr == 0xdeadbeef || (bytes.Length > 4 && GetOpCode(bytes) == OpCodes.PKTAuthTokenResult && bytes[0] == 0x1e))
                        {
                            beforeNewZone?.Invoke();
                            onNewZone?.Invoke();
                            currentIpAddr = srcAddr;
                        }
                        else return;
                    }
                    Logger.DoDebugLog(bytes);
                    try {
                        ProcessPacket(bytes.ToList());
                    } catch (Exception e) {
                        // Console.WriteLine("Failure during processing of packet: " + e);
                    }
                }
            }
        }
        private void Parser_onDamageEvent(LogInfo log)
        {
            currentEncounter.Infos.Add(log);
        }

        private void Parser_onStatusEffectEnded(StatusEffect statusEffect, TimeSpan duration)
        {
            Entity dstEntity;
            if (statusEffect.Type == StatusEffect.StatusEffectType.Party)
                dstEntity = currentEncounter.PartyEntities.GetOrAdd(statusEffect.TargetId);
            else
                dstEntity = currentEncounter.Entities.GetOrAdd(statusEffect.TargetId);
            var log = new LogInfo
            {
                Time = DateTime.Now,
                SourceEntity = currentEncounter.Entities.GetOrAdd(statusEffect.SourceId),
                DestinationEntity = dstEntity,
                SkillEffectId = statusEffect.StatusEffectId,
                SkillName = SkillBuff.GetSkillBuffName(statusEffect.StatusEffectId),
                Damage = 0,
                Duration = duration
            };
            currentEncounter.Infos.Add(log);
            Logger.AppendLog(11, statusEffect.StatusEffectId.ToString("X"), SkillBuff.GetSkillBuffName(statusEffect.StatusEffectId), statusEffect.TargetId.ToString("X"), currentEncounter.Entities.GetOrAdd(statusEffect.TargetId).Name);

        }
        private void StatusEffectTracker_OnStatusEffectStarted(StatusEffect statusEffect)
        {
            Logger.AppendLog(10, statusEffect.SourceId.ToString("X"), currentEncounter.Entities.GetOrAdd(statusEffect.SourceId).Name, statusEffect.StatusEffectId.ToString("X"), SkillBuff.GetSkillBuffName(statusEffect.StatusEffectId), statusEffect.TargetId.ToString("X"), currentEncounter.Entities.GetOrAdd(statusEffect.TargetId).Name, statusEffect.Value.ToString());
        }

        private void Parser_onNewZone()
        {
            //Logger.StartNewLogFile();
            loggedPacketCount = 0;
        }

        public Entity GetSourceEntity(UInt64 sourceId)
        {
            var sourceEntity = currentEncounter.Entities.GetOrAdd(sourceId);
            if (sourceEntity.Type == Entity.EntityType.Projectile)
                sourceEntity = currentEncounter.Entities.GetOrAdd(sourceEntity.OwnerId);
            if (sourceEntity.Type == Entity.EntityType.Summon)
                sourceEntity = currentEncounter.Entities.GetOrAdd(sourceEntity.OwnerId);
            return sourceEntity;
        }
        public void UninstallListeners()
        {
            if (tcp != null) tcp.Stop();
            if (pcap != null)
            {
                try
                {
                    pcap.StopCapture();
                    pcap.Close();
                }
                catch (Exception ex)
                {
                    var exceptionMessage = "Exception while trying to stop capture on NIC " + pcap.Name + "\n" + ex.ToString();
                    Console.WriteLine(exceptionMessage);
                    Logger.AppendLog(254, exceptionMessage);
                }
            }
            tcp = null;
            pcap = null;
        }

        public void Dispose()
        {

        }
    }
}
