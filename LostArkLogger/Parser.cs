using K4os.Compression.LZ4;
using Snappy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using SharpPcap;
using LostArkLogger.Utilities;
using System.Net.NetworkInformation;

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
        public event Action<int> onPacketTotalCount;
        public bool enableLogging = true;
        public bool use_npcap = false;
        private object lockPacketProcessing = new object(); // needed to synchronize UI swapping devices
        public Machina.Infrastructure.NetworkMonitorType? monitorType = null;
        public List<Encounter> Encounters = new List<Encounter>();
        public Encounter currentEncounter = new Encounter();
        Byte[] fragmentedPacket = new Byte[0];
        private string _localPlayerName = "You";

        public enum Region : Byte
        {
            Steam,
            Korea,
            Russia
        }
        public Region region = Region.Steam;
        public Parser()
        {
            Encounters.Add(currentEncounter);
            onCombatEvent += AppendLog;
            onCombatEvent += Parser_onDamageEvent;
            onNewZone += Parser_onNewZone;

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
                                    //Console.WriteLine("Exception while trying to listen to NIC {0}:\n{1}", device.Name, ex.ToString());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Sharppcap init failed, using rawsockets instead, exception:\n{0}", ex.ToString());
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

        void ProcessDamageEvent(Entity sourceEntity, UInt32 skillId, UInt32 subSkillId, SkillDamageEvent dmgEvent)
        {
            var skillName = Skill.GetSkillName(skillId, subSkillId);
            var targetEntity = currentEncounter.Entities.GetOrAdd((uint) dmgEvent.TargetId);
            var destinationName = targetEntity != null ? targetEntity.VisibleName : dmgEvent.TargetId.ToString("X");
            //var log = new LogInfo { Time = DateTime.Now, Source = sourceName, PC = sourceName.Contains("("), Destination = destinationName, SkillName = skillName, Crit = (dmgEvent.FlagsMaybe & 0x81) > 0, BackAttack = (dmgEvent.FlagsMaybe & 0x10) > 0, FrontAttack = (dmgEvent.FlagsMaybe & 0x20) > 0 };
            var log = new LogInfo
            {
                Time = DateTime.Now, SourceEntity = sourceEntity, DestinationEntity = targetEntity, SkillId = skillId,
                SkillSubId = subSkillId, SkillName = skillName, Damage = (ulong) dmgEvent.Damage, Crit =
                    ((DamageModifierFlags) dmgEvent.Modifier &
                     (DamageModifierFlags.DotCrit |
                      DamageModifierFlags.SkillCrit)) > 0,
                BackAttack = ((DamageModifierFlags) dmgEvent.Modifier & (DamageModifierFlags.BackAttack)) > 0,
                FrontAttack = ((DamageModifierFlags) dmgEvent.Modifier & (DamageModifierFlags.FrontAttack)) > 0
            };
            onCombatEvent?.Invoke(log);
        }
        void ProcessSkillDamage(PKTSkillDamageNotify damage)
        {
            var sourceEntity = currentEncounter.Entities.GetOrAdd((ulong) damage.SourceId);
            if (sourceEntity.Type == Entity.EntityType.Projectile)
                sourceEntity = currentEncounter.Entities.GetOrAdd(sourceEntity.OwnerId);
            if (sourceEntity.Type == Entity.EntityType.Summon)
                sourceEntity = currentEncounter.Entities.GetOrAdd(sourceEntity.OwnerId);
            var className = Skill.GetClassFromSkill((uint) damage.SkillId);
            if (String.IsNullOrEmpty(sourceEntity.ClassName) && className != "UnknownClass")
            {
                sourceEntity.Type = Entity.EntityType.Player;
                sourceEntity.ClassName = className; // for case where we don't know user's class yet            
            }

            if (String.IsNullOrEmpty(sourceEntity.Name)) sourceEntity.Name = damage.SourceId.ToString("X");
            foreach (var dmgEvent in damage.skillDamageEvents.skillDamageEvents)
                ProcessDamageEvent(sourceEntity, (uint) damage.SkillId, (uint) damage.SkillEffectId, dmgEvent);
        }

        void ProcessSkillDamage(PKTSkillDamageAbnormalMoveNotify damage)
        {
            var sourceEntity = currentEncounter.Entities.GetOrAdd((ulong)damage.SourceId);
            if (sourceEntity.Type == Entity.EntityType.Projectile)
                sourceEntity = currentEncounter.Entities.GetOrAdd(sourceEntity.OwnerId);
            if (sourceEntity.Type == Entity.EntityType.Summon)
                sourceEntity = currentEncounter.Entities.GetOrAdd(sourceEntity.OwnerId);
            var className = Skill.GetClassFromSkill((uint)damage.SkillId);
            if (String.IsNullOrEmpty(sourceEntity.ClassName) && className != "UnknownClass")
            {
                sourceEntity.Type = Entity.EntityType.Player;
                sourceEntity.ClassName = className; // for case where we don't know user's class yet            
            }

            if (String.IsNullOrEmpty(sourceEntity.Name)) sourceEntity.Name = damage.SourceId.ToString("X");
            foreach (var dmgEvent in damage.skillDamageMoveEvents.skillDamageMoveEvents)
                ProcessDamageEvent(sourceEntity, (uint)damage.SkillId, (uint)damage.SkillEffectId, dmgEvent.skillDamageEvent);
        }

        OpCodes GetOpCode(Byte[] packets)
        {
            var opcodeVal = BitConverter.ToUInt16(packets, 2);
            var opCodeString = "";
            if (region == Region.Steam) opCodeString = ((OpCodes_steam)opcodeVal).ToString();
            if (region == Region.Russia) opCodeString = ((OpCodes_ru)opcodeVal).ToString();
            if (region == Region.Korea) opCodeString = ((OpCodes_kr)opcodeVal).ToString(); // broke atm
            return (OpCodes)Enum.Parse(typeof(OpCodes), opCodeString);
        }
        Byte[] XorTableSteam = ObjectSerialize.Decompress(Properties.Resources.xor_steam);
        Byte[] XorTableRu = ObjectSerialize.Decompress(Properties.Resources.xor_ru);
        Byte[] XorTableKr = ObjectSerialize.Decompress(Properties.Resources.xor_kr);
        Byte[] XorTable { get { return region == Region.Steam ? XorTableSteam : region == Region.Russia ? XorTableRu : XorTableKr; } }
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
                    fragmentedPacket = packets.ToArray();
                    return;
                }
                var payload = packets.Skip(6).Take(packetSize - 6).ToArray();
                Xor.Cipher(payload, BitConverter.ToUInt16(packets, 2), XorTable);
                switch (packets[4])
                {
                    case 1: //LZ4
                        var buffer = new byte[0x11ff2];
                        var result = LZ4Codec.Decode(payload, 0, payload.Length, buffer, 0, 0x11ff2);
                        if (result < 1) throw new Exception("LZ4 output buffer too small");
                        payload = buffer.Take(result).ToArray(); //TODO: check LZ4 payload and see if we should skip some data
                        break;
                    case 2: //Snappy
                        //https://github.com/robertvazan/snappy.net
                        payload = SnappyCodec.Uncompress(payload.Skip(region == Region.Russia ? 4 : 0).ToArray()).Skip(16).ToArray();
                        break;
                    case 3: //Oodle
                        payload = Oodle.Decompress(payload).Skip(16).ToArray();
                        break;
                }

                // write packets for analyzing, bypass common, useless packets
                //if (opcode != OpCodes.PKTMoveError && opcode != OpCodes.PKTMoveNotify && opcode != OpCodes.PKTMoveNotifyList && opcode != OpCodes.PKTTransitStateNotify && opcode != OpCodes.PKTPing && opcode != OpCodes.PKTPong)
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
                if (opcode == OpCodes.PKTNewProjectile)
                {
                    var projectile = new PKTNewProjectile(new BitReader(payload)).Info;
                    currentEncounter.Entities.AddOrUpdate(new Entity
                    {
                        OwnerId = (ulong) projectile.OwnerId,
                        EntityId = (ulong) projectile.ProjectileId,
                        Type = Entity.EntityType.Projectile
                    });
                }
                else if (opcode == OpCodes.PKTNewNpc)
                {
                    var npc = new PKTNewNpc(new BitReader(payload)).npcStruct;
                    currentEncounter.Entities.AddOrUpdate(new Entity
                    {
                        EntityId = (ulong) npc.NpcId,
                        Name = Npc.GetNpcName((uint) npc.NpcType), Type = Entity.EntityType.Npc
                    });
                }
                else if (opcode == OpCodes.PKTNewPC)
                {
                    var pc = new PKTNewPC(new BitReader(payload)).pCStruct;
                    currentEncounter.Entities.AddOrUpdate(new Entity
                    {
                        EntityId = (ulong) pc.PlayerId, Name = pc.Name,
                        ClassName = Npc.GetPcClass((uint) pc.ClassId),
                        Type = Entity.EntityType.Player
                    });
                }
                else if (opcode == OpCodes.PKTInitEnv)
                {
                    var env = new PKTInitEnv(new BitReader(payload));
                    if (currentEncounter.Infos.Count == 0) Encounters.Remove(currentEncounter);
                    currentEncounter = new Encounter();
                    Encounters.Add(currentEncounter);

                    currentEncounter.Entities.AddOrUpdate(new Entity
                        {EntityId = (ulong) env.PlayerId, Name = _localPlayerName, Type = Entity.EntityType.Player});
                    onNewZone?.Invoke();
                }
                else if (opcode == OpCodes.PKTInitPC)
                {
                    var pc = new PKTInitPC(new BitReader(payload));
                    if (currentEncounter.Infos.Count == 0) Encounters.Remove(currentEncounter);
                    currentEncounter = new Encounter();
                    Encounters.Add(currentEncounter);
                    _localPlayerName = pc.Name;
                    currentEncounter.Entities.AddOrUpdate(new Entity
                    {
                        EntityId = (ulong) pc.PlayerId, Name = _localPlayerName,
                        Type = Entity.EntityType.Player
                    });
                    onNewZone?.Invoke();
                }
                else if (opcode == OpCodes.PKTRaidResult // raid over
                         || opcode == OpCodes.PKTRaidBossKillNotify // boss dead, includes argos phases
                         || opcode == OpCodes.PKTTriggerBossBattleStatus) // wipe
                {
                    currentEncounter.End = DateTime.Now;
                    currentEncounter = new Encounter();
                    if (opcode == OpCodes.PKTRaidBossKillNotify || opcode == OpCodes.PKTTriggerBossBattleStatus)
                        currentEncounter.Entities = Encounters.Last().Entities; // preserve entities 
                    Encounters.Add(currentEncounter);
                }
                /*if ((OpCodes)BitConverter.ToUInt16(converted.ToArray(), 2) == OpCodes.PKTRemoveObject)
                {
                    var projectile = new PKTRemoveObject { Bytes = converted };
                    ProjectileOwner.Remove(projectile.ProjectileId, projectile.OwnerId);
                }*/
                else if (opcode == OpCodes.PKTSkillDamageNotify)
                    ProcessSkillDamage(new PKTSkillDamageNotify(new BitReader(payload)));
                else if (opcode == OpCodes.PKTSkillDamageAbnormalMoveNotify)
                    ProcessSkillDamage(new PKTSkillDamageAbnormalMoveNotify(payload));
                /*else if (opcode == OpCodes.PKTStatChangeOriginNotify) // bard heal
                {
                    var health = new PKTStatChangeOriginNotify(new BitReader(payload));
                    var log = new LogInfo
                    {
                        Time = DateTime.Now, SourceEntity = currentEncounter.Entities.GetOrAdd(health.ObjectId),
                        DestinationEntity = currentEncounter.Entities.GetOrAdd(health.ObjectId),
                        Heal = (UInt32)health.StatPairChangedList.Values[0]
                    };
                    onCombatEvent?.Invoke(log);
                }
                else if (opcode == OpCodes.PKTParalyzationStateNotify) // stagger
                {
                    var buff = new PKTStatusEffectAddNotify(new BitReader(payload));
                    //Console.WriteLine(buff.ObjectId.ToString("X") + " : " + buff.field2.ToString("X") + " : " + buff.statusEffectData.field2.ToString("X") + " : " + buff.statusEffectData.field3.ToString("X") + " : " + buff.statusEffectData.field10.ToString("X") + " : " + buff.statusEffectData.field5 + " : " + buff.statusEffectData.field9.num + " : " +( buff.statusEffectData.hasValue == 1 ? BitConverter.ToString(buff.statusEffectData.Value) : ""));
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
                    var log = new LogInfo
                    {
                        Time = DateTime.Now, SourceEntity = currentEncounter.Entities.GetOrAdd(counter.SourceId), DestinationEntity = currentEncounter.Entities.GetOrAdd(counter.TargetId), SkillName = "Counter",
                        Damage = 0, Counter = true
                    };
                    onCombatEvent?.Invoke(log);
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

        static string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        static string loaPath = Path.Combine(documentsPath, "LOA Details");
        static string logsPath = Path.Combine(loaPath, "Logs");

        public Boolean debugLog = false;
        BinaryWriter logger;
        FileStream logStream;
        UInt32 currentIpAddr = 0xdeadbeef;
        string fileName = logsPath + "\\LostArk_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";
        
        int loggedPacketCount = 0;

        void AppendLog(LogInfo s)
        {
            if (enableLogging) File.AppendAllText(fileName, s.ToString() + "\n");
        }
        void DoDebugLog(byte[] bytes) {
            if (debugLog)
            {
                if (logger == null)
                {
                    logStream = new FileStream(fileName.Replace(".log", ".bin"), FileMode.Create);
                    logger = new BinaryWriter(logStream);
                }
                logger.Write(BitConverter.GetBytes(DateTime.Now.ToBinary()).Concat(BitConverter.GetBytes(bytes.Length)).Concat(bytes).ToArray());
            }
        }

        void Device_OnPacketArrival_machina(Machina.Infrastructure.TCPConnection connection, byte[] bytes)
        {
            if (tcp == null) return; // To avoid any late delegate calls causing state issues when listener uninstalled
            lock (lockPacketProcessing)
            {
                if (connection.RemotePort != 6040) return;
                var srcAddr = connection.RemoteIP;
                if (srcAddr != currentIpAddr)
                {
                    if (currentIpAddr == 0xdeadbeef || (bytes.Length > 4 && (OpCodes)BitConverter.ToUInt16(bytes, 2) == OpCodes.PKTAuthTokenResult && bytes[0] == 0x1e))
                    {
                        onNewZone?.Invoke();
                        currentIpAddr = srcAddr;
                    }
                    else return;
                }
                DoDebugLog(bytes);
                ProcessPacket(bytes.ToList());
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
                        if (currentIpAddr == 0xdeadbeef || (bytes.Length > 4 && (OpCodes)BitConverter.ToUInt16(bytes, 2) == OpCodes.PKTAuthTokenResult && bytes[0] == 0x1e))
                        {
                            onNewZone?.Invoke();
                            currentIpAddr = srcAddr;
                            fileName = logsPath + "\\LostArk_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";
                            loggedPacketCount = 0;
                        }
                        else return;
                    }
                    DoDebugLog(bytes);
                    ProcessPacket(bytes.ToList());
                }
            }
        }
        private void Parser_onDamageEvent(LogInfo log)
        {
            currentEncounter.Infos.Add(log);
        }
        private void Parser_onNewZone()
        {
        }
        public void UninstallListeners()
        {
            logger?.Dispose();
            logStream?.Dispose();
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
                    //Console.WriteLine("Exception while trying to stop capture on NIC {0}:\n{1}", pcap.Name, ex.ToString());
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
