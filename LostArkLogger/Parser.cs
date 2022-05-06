using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Snappy;
using K4os.Compression.LZ4;

namespace LostArkLogger
{
    internal class Parser : IDisposable
    {
        Machina.TCPNetworkMonitor tcp;
        MainWindow main;
        public Action newZone;
        public Action<LogInfo> addDamageEvent;
        public Parser(MainWindow m)
        {
            main = m;
            var tcp = new Machina.TCPNetworkMonitor();
            tcp.Config.WindowName = "LOST ARK (64-bit, DX11) v.2.2.3.1";
            tcp.Config.MonitorType = Machina.Infrastructure.NetworkMonitorType.RawSocket;
            tcp.DataReceivedEventHandler += (Machina.Infrastructure.TCPConnection connection, byte[] data) => Device_OnPacketArrival(connection, data);
            tcp.Start();            
        }
        public Dictionary<UInt64, UInt64> ProjectileOwner = new Dictionary<UInt64, UInt64>();
        public Dictionary<UInt64, String> IdToName = new Dictionary<UInt64, String>();
        public Dictionary<String, String> NameToClass = new Dictionary<String, String>();
        Byte[] fragmentedPacket = new Byte[0];
        void ProcessPacket(List<Byte> data)
        {
            var packets = data.ToArray();
            var packetWithTimestamp = BitConverter.GetBytes(DateTime.UtcNow.ToBinary()).ToArray().Concat(data);
            loggedPacketCount++;
            main.loggedPacketCountLabel.Text = "Logged Packets : " + loggedPacketCount;
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
                if (opcode == OpCodes.PKTNewProjectile)
                    ProjectileOwner[BitConverter.ToUInt64(payload, 4)] = BitConverter.ToUInt64(payload, 4 + 8);
                else if (opcode == OpCodes.PKTNewNpc)
                {
                    var npcName = Npc.GetNpcName(BitConverter.ToUInt32(payload, 15));
                    IdToName[BitConverter.ToUInt64(payload, 7)] = npcName;
                }
                else if (opcode == OpCodes.PKTNewPC)
                {
                    var pc = new PKTNewPC(payload);
                    var pcClass = Npc.GetPcClass(pc.ClassId);
                    if (!NameToClass.ContainsKey(pc.Name)) NameToClass[pc.Name] = pcClass + (NameToClass.ContainsValue(pcClass) ? (" - " + Guid.NewGuid().ToString().Substring(0, 4)) : "");
                    IdToName[pc.PlayerId] = pc.Name + " (" + pcClass + ")";
                }
                else if (opcode == OpCodes.PKTInitEnv)
                {
                    var pc = new PKTInitEnv(payload);
                    IdToName[pc.PlayerId] = "You";
                    newZone?.Invoke();
                }
                /*if ((OpCodes)BitConverter.ToUInt16(converted.ToArray(), 2) == OpCodes.PKTRemoveObject)
                {
                    var projectile = new PKTRemoveObject { Bytes = converted };
                    ProjectileOwner.Remove(projectile.ProjectileId, projectile.OwnerId);
                }*/
                else if (opcode == OpCodes.PKTSkillDamageNotify)
                {
                    var damage = new PKTSkillDamageNotify(payload);
                    {
                        foreach (var dmgEvent in damage.Events)
                        {
                            var skillName = Skill.GetSkillName(damage.SkillId, damage.SkillIdWithState);
                            var ownerId = ProjectileOwner.ContainsKey(damage.PlayerId) ? ProjectileOwner[damage.PlayerId] : damage.PlayerId;
                            var sourceName = IdToName.ContainsKey(ownerId) ? IdToName[ownerId] : ownerId.ToString("X");
                            var destinationName = IdToName.ContainsKey(dmgEvent.TargetId) ? IdToName[dmgEvent.TargetId] : dmgEvent.TargetId.ToString("X");
                            if (sourceName == "You" && Skill.GetClassFromSkill(damage.SkillId) != "UnknownClass")
                            {
                                var myClass = Skill.GetClassFromSkill(damage.SkillId);
                                if (myClass != "UnknownClass") sourceName = IdToName[ownerId] = "You (" + myClass + ")";
                            }
                            //var log = new LogInfo { Time = DateTime.Now, Source = sourceName, PC = sourceName.Contains("("), Destination = destinationName, SkillName = skillName, Crit = (dmgEvent.FlagsMaybe & 0x81) > 0, BackAttack = (dmgEvent.FlagsMaybe & 0x10) > 0, FrontAttack = (dmgEvent.FlagsMaybe & 0x20) > 0 };
                            var log = new LogInfo { Time = DateTime.Now, Source = sourceName, PC = true, Destination = destinationName, SkillName = skillName, Damage = dmgEvent.Damage, Crit = (dmgEvent.FlagsMaybe & 0x81) > 0, BackAttack = (dmgEvent.FlagsMaybe & 0x10) > 0, FrontAttack = (dmgEvent.FlagsMaybe & 0x20) > 0 };
                            AppendLog(log.ToString());
                            addDamageEvent?.Invoke(log);
                        }
                    }
                }
                else if (opcode == OpCodes.PKTSkillDamageAbnormalMoveNotify)
                {
                    var damage = new PKTSkillDamageAbnormalMoveNotify(payload);
                    //for (var i = 0; i < payload.Length - 4; i++)
                    //    Console.WriteLine(i + " : " + BitConverter.ToUInt32(payload, i) + " : " + BitConverter.ToUInt32(payload, i).ToString("X"));
                    // normal mobs when skills make them move. not needed for boss tracking, since guardians don't get moved by abilities. this will show more damage taken by players
                }
                if (packets.Length < packetSize) throw new Exception("bad packet maybe");
                packets = packets.Skip(packetSize).ToArray();
            }
        }
        UInt32 currentIpAddr = 0xdeadbeef;
        string fileName;
        int loggedPacketCount = 0;
        void AppendLog(String s)
        {
            if (main.logEnabled.Checked) File.AppendAllText(fileName, s + "\n");
        }
        void Device_OnPacketArrival(Machina.Infrastructure.TCPConnection connection, byte[] bytes)
        {
            if (connection.RemotePort != 6040) return;
            var srcAddr = connection.RemoteIP;
            if (srcAddr != currentIpAddr)
            {
                if (currentIpAddr == 0xdeadbeef || (bytes.Length > 4 && (OpCodes)BitConverter.ToUInt16(bytes, 2) == OpCodes.PKTAuthTokenResult && bytes[0] == 0x1e))
                {
                    newZone?.Invoke();
                    currentIpAddr = srcAddr;
                    fileName = "logs\\LostArk_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";
                    loggedPacketCount = 0;
                }
                else return;
            }
            ProcessPacket(bytes.ToList());
        }

        public void Dispose()
        {
            tcp.Stop();
        }
    }
}
