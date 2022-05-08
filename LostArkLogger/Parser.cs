using K4os.Compression.LZ4;
using Snappy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace LostArkLogger
{
    internal class Parser : IDisposable
    {
        Machina.TCPNetworkMonitor tcp;
        public event Action<LogInfo> onCombatEvent;
        public event Action onNewZone;
        public event Action<int> onPacketTotalCount;
        public bool enableLogging = true;
        public Parser()
        {
            Encounters.Add(currentEncounter);
            onCombatEvent += AppendLog;
            onCombatEvent += Parser_onDamageEvent;
            onNewZone += Parser_onNewZone;

            tcp = new Machina.TCPNetworkMonitor();
            tcp.Config.WindowClass = "EFLaunchUnrealUWindowsClient";
            tcp.Config.MonitorType = Machina.Infrastructure.NetworkMonitorType.RawSocket;
            tcp.DataReceivedEventHandler += (Machina.Infrastructure.TCPConnection connection, byte[] data) => Device_OnPacketArrival(connection, data);
            tcp.Start();
        }
#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
        [DllImport("wpcap.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)] static extern IntPtr pcap_strerror(int err);
#pragma warning restore CA2101 // Specify marshaling for P/Invoke string arguments
        public List<Encounter> Encounters = new List<Encounter>();
        public Encounter currentEncounter = new Encounter();
        Byte[] fragmentedPacket = new Byte[0];
        void ProcessDamageEvent(Entity sourceEntity, UInt32 skillId, UInt32 subSkillId, PKTSkillDamageNotify.SkillDamageNotifyEvent dmgEvent)
        {
            var skillName = Skill.GetSkillName(skillId, subSkillId);
            var targetEntity = currentEncounter.Entities.GetOrAdd(dmgEvent.TargetId);
            var destinationName = targetEntity != null ? targetEntity.VisibleName : dmgEvent.TargetId.ToString("X");
            //var log = new LogInfo { Time = DateTime.Now, Source = sourceName, PC = sourceName.Contains("("), Destination = destinationName, SkillName = skillName, Crit = (dmgEvent.FlagsMaybe & 0x81) > 0, BackAttack = (dmgEvent.FlagsMaybe & 0x10) > 0, FrontAttack = (dmgEvent.FlagsMaybe & 0x20) > 0 };
            var log = new LogInfo { Time = DateTime.Now, SourceEntity = sourceEntity, DestinationEntity = targetEntity, SkillId = skillId, SkillSubId = subSkillId, SkillName = skillName, Damage = dmgEvent.Damage, Crit = (dmgEvent.FlagsMaybe & 0x81) > 0, BackAttack = (dmgEvent.FlagsMaybe & 0x10) > 0, FrontAttack = (dmgEvent.FlagsMaybe & 0x20) > 0 };
            onCombatEvent?.Invoke(log);
        }
        void ProcessSkillDamage(PKTSkillDamageNotify damage)
        {
            var sourceEntity = currentEncounter.Entities.GetOrAdd(damage.PlayerId);
            if (sourceEntity.Type == Entity.EntityType.Projectile)
                sourceEntity = currentEncounter.Entities.GetOrAdd(sourceEntity.OwnerId);
            if (sourceEntity.Type == Entity.EntityType.Summon)
                sourceEntity = currentEncounter.Entities.GetOrAdd(sourceEntity.OwnerId);
            var className = Skill.GetClassFromSkill(damage.SkillId);
            if (String.IsNullOrEmpty(sourceEntity.ClassName) && className != "UnknownClass") sourceEntity.ClassName = className; // for case where we don't know user's class yet            
            if (String.IsNullOrEmpty(sourceEntity.Name)) sourceEntity.Name = damage.PlayerId.ToString("X");
            foreach (var dmgEvent in damage.Events) ProcessDamageEvent(sourceEntity, damage.SkillId, damage.SkillIdWithState, dmgEvent);
        }
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
                var opcode = (OpCodes)BitConverter.ToUInt16(packets, 2);
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
                Xor.Cipher(payload, (UInt16)opcode);
                switch (packets[4])
                {
                    case 1: //LZ4
                        var buffer = new byte[0x11ff2];
                        var result = LZ4Codec.Decode(payload, 0, payload.Length, buffer, 0,
                            0x11ff2);
                        if (result < 1)
                            throw new Exception("LZ4 output buffer too small");
                        payload = buffer.Take(result)
                            .ToArray(); //TODO: check LZ4 payload and see if we should skip some data
                        break;
                    case 2: //Snappy
                        //https://github.com/robertvazan/snappy.net
                        payload = SnappyCodec.Uncompress(payload).Skip(16).ToArray();
                        break;
                    case 3: //Oodle
                        payload = Oodle.Decompress(payload).Skip(16).ToArray();
                        break;
                }

                // write packets for analyzing, bypass common, useless packets
                //if (opcode != OpCodes.PKTMoveError && opcode != OpCodes.PKTMoveNotify && opcode != OpCodes.PKTMoveNotifyList && opcode != OpCodes.PKTTransitStateNotify && opcode != OpCodes.PKTPing && opcode != OpCodes.PKTPong)
                //    Console.WriteLine(opcode + " : " + BitConverter.ToString(payload));

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
                    currentEncounter.Entities.AddOrUpdate(new Entity { EntityId = BitConverter.ToUInt64(payload, 4), OwnerId = BitConverter.ToUInt64(payload, 4 + 8), Type = Entity.EntityType.Projectile });
                else if (opcode == OpCodes.PKTNewNpc)
                {
                    currentEncounter.Entities.AddOrUpdate(new Entity { EntityId = BitConverter.ToUInt64(payload, 7), Name = Npc.GetNpcName(BitConverter.ToUInt32(payload, 15)), Type = Entity.EntityType.Npc });
                }
                else if (opcode == OpCodes.PKTNewPC)
                {
                    var pc = new PKTNewPC(payload);
                    currentEncounter.Entities.AddOrUpdate(new Entity { EntityId = pc.PlayerId, Name = pc.Name, ClassName = Npc.GetPcClass(pc.ClassId), Type = Entity.EntityType.Player });
                }
                else if (opcode == OpCodes.PKTInitEnv)
                {
                    var pc = new PKTInitEnv(payload);
                    if (currentEncounter.Infos.Count == 0) Encounters.Remove(currentEncounter);
                    currentEncounter = new Encounter();
                    Encounters.Add(currentEncounter);
                    currentEncounter.Entities.AddOrUpdate(new Entity { EntityId = pc.PlayerId, Name = "You", Type = Entity.EntityType.Player });
                    onNewZone?.Invoke();
                }
                else if (opcode == OpCodes.PKTRaidResult)
                {
                    currentEncounter.End = DateTime.Now;
                    currentEncounter = new Encounter();
                    Encounters.Add(currentEncounter);
                }
                /*if ((OpCodes)BitConverter.ToUInt16(converted.ToArray(), 2) == OpCodes.PKTRemoveObject)
                {
                    var projectile = new PKTRemoveObject { Bytes = converted };
                    ProjectileOwner.Remove(projectile.ProjectileId, projectile.OwnerId);
                }*/
                else if (opcode == OpCodes.PKTSkillDamageNotify)
                    ProcessSkillDamage(new PKTSkillDamageNotify(payload));
                else if (opcode == OpCodes.PKTSkillDamageAbnormalMoveNotify)
                    ProcessSkillDamage(new PKTSkillDamageAbnormalMoveNotify(payload));
                else if (opcode == OpCodes.PKTStatChangeOriginNotify) // bard heal
                {
                    var health = new PKTStatChangeOriginNotify(payload);
                    //Console.WriteLine(health.HealAmount + " : " + health.NewHealth);
                    //var log = new LogInfo { Time = DateTime.Now, SourceEntity = currentEncounter.Entities.GetOrAdd(health.PlayerId), Damage = -(Int64)health.HealAmount };
                    //onCombatEvent?.Invoke(log);
                }
                else if (opcode == OpCodes.PKTParalyzationStateNotify)
                {
                    var stagger = new PKTParalyzationStateNotify(payload);
                    var enemy = currentEncounter.Entities.GetOrAdd(stagger.TargetId);
                    var lastInfo = currentEncounter.Infos.LastOrDefault(); // hope this works
                    var player = lastInfo?.SourceEntity;
                    var staggerAmount = stagger.ParalyzationPoint - enemy.Stagger;
                    if (stagger.ParalyzationPoint == 0) staggerAmount = stagger.ParalyzationPointMax - enemy.Stagger;
                    enemy.Stagger = stagger.ParalyzationPoint;
                    var log = new LogInfo { Time = DateTime.Now, SourceEntity = player, DestinationEntity = enemy, SkillName = lastInfo?.SkillName, Stagger = staggerAmount };
                    onCombatEvent?.Invoke(log);
                }
                else if (opcode == OpCodes.PKTCounterAttackNotify)
                {
                    var counter = new PKTCounterAttackNotify(payload);
                    var player = currentEncounter.Entities.GetOrAdd(counter.PlayerId);
                    var enemy = currentEncounter.Entities.GetOrAdd(counter.EnemyId);
                    var log = new LogInfo { Time = DateTime.Now, SourceEntity = player, DestinationEntity = enemy, SkillName = "Counter", Damage = 0, Counter = true };
                    onCombatEvent?.Invoke(log);
                }
                else if (opcode == OpCodes.PKTNewNpcSummon)
                    currentEncounter.Entities.AddOrUpdate(new Entity { EntityId = BitConverter.ToUInt64(payload, 44), OwnerId = BitConverter.ToUInt64(payload, 0), Type = Entity.EntityType.Summon });
                if (packets.Length < packetSize) throw new Exception("bad packet maybe");
                packets = packets.Skip(packetSize).ToArray();
            }
        }
        UInt32 currentIpAddr = 0xdeadbeef;
        string fileName = "logs\\LostArk_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";
        int loggedPacketCount = 0;

        void AppendLog(LogInfo s)
        {
            if (enableLogging) File.AppendAllText(fileName, s.ToString() + "\n");
        }
        public Boolean debugLog = false;
        BinaryWriter logger;
        FileStream logStream;
        void Device_OnPacketArrival(Machina.Infrastructure.TCPConnection connection, byte[] bytes)
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
            if (debugLog)
            {
                if (logger == null)
                {
                    logStream = new FileStream(fileName.Replace(".log", ".bin"), FileMode.Create);
                    logger = new BinaryWriter(logStream);
                }
                logger.Write(BitConverter.GetBytes(DateTime.Now.ToBinary()).Concat(BitConverter.GetBytes(bytes.Length)).Concat(bytes).ToArray());
            }
            ProcessPacket(bytes.ToList());
        }
        private void Parser_onDamageEvent(LogInfo log)
        {
            currentEncounter.Infos.Add(log);
        }
        private void Parser_onNewZone()
        {
        }

        public void Dispose()
        {
            logger?.Dispose();
            logStream?.Dispose();
            tcp.Stop();
        }
    }
}
