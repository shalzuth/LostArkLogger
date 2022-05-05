using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace LostArkLogger
{
    internal class Sniffer : IDisposable
    {
        Socket socket;
        Byte[] packetBuffer = new Byte[0x10000];
        MainWindow main;
        public Action newZone;
        public Action<LogInfo> addDamageEvent;
        public Sniffer(MainWindow m)
        {
            main = m;
            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            socket.Bind(new IPEndPoint(GetLocalIPAddress(), 0));
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);
            socket.IOControl(IOControlCode.ReceiveAll, BitConverter.GetBytes(1), BitConverter.GetBytes(0));
            socket.BeginReceive(packetBuffer, 0, packetBuffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
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
                if (packetSize > packets.Length)
                {
                    fragmentedPacket = packets.ToArray();
                    return;
                }
                if (packetSize == 0) return;
                if (packets[5] != 1 || 6 > packets.Length || packetSize < 7) return;
                var payload = packets.Skip(6).Take(packetSize - 6).ToArray();
                Xor.Cipher(payload, (UInt16)opcode);
                if (packets[4] == 3) payload = Oodle.Decompress(payload).Skip(16).ToArray();
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
        public static IPAddress GetLocalIPAddress()
        {
            try
            {
                var tempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                var ipEndpoint = new IPEndPoint(IPAddress.Parse("8.8.8.8"), 6040).Serialize();
                var optionIn = new Byte[ipEndpoint.Size];
                for (int i = 0; i < ipEndpoint.Size; i++) optionIn[i] = ipEndpoint[i];
                var optionOut = new Byte[optionIn.Length];
                tempSocket.IOControl(IOControlCode.RoutingInterfaceQuery, optionIn, optionOut);
                tempSocket.Close();
                return new IPAddress(optionOut.Skip(4).Take(4).ToArray());
            }
            catch
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                //var activeDevice = NetworkInterface.GetAllNetworkInterfaces().First(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback);
                //var activeDeviceIpProp = activeDevice.GetIPProperties().UnicastAddresses.Select(a => a.Address.AddressFamily == AddressFamily.InterNetwork);
                var ipAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
                return ipAddress;
            }
        }
        TcpReconstruction tcpReconstruction;
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                var bytesRead = socket?.EndReceive(ar);
                if (bytesRead > 0)
                {
                    Device_OnPacketArrival(packetBuffer.Take((int)bytesRead).ToArray());
                    packetBuffer = new Byte[packetBuffer.Length];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            socket?.BeginReceive(packetBuffer, 0, packetBuffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
        }
        UInt32 currentIpAddr = 0xdeadbeef;
        string fileName;
        int loggedPacketCount = 0;
        void AppendLog(String s)
        {
            if (main.logEnabled.Checked) File.AppendAllText(fileName, s + "\n");
        }
        void Device_OnPacketArrival(Byte[] bytes)
        {
            if ((ProtocolType)bytes[9] == ProtocolType.Tcp)
            {
                var tcp = new PacketDotNet.TcpPacket(new PacketDotNet.Utils.ByteArraySegment(bytes.Skip(20).ToArray()));
                if (tcp.SourcePort != 6040) return; // this filter should be moved up before parsing to TcpPacket for performance
                var srcAddr = BitConverter.ToUInt32(bytes, 12);
                if (srcAddr != currentIpAddr)
                {
                    if (currentIpAddr == 0xdeadbeef || (tcp.PayloadData.Length > 4 && (OpCodes)BitConverter.ToUInt16(tcp.PayloadData, 2) == OpCodes.PKTAuthTokenResult && tcp.PayloadData[0] == 0x1e))
                    {
                        newZone?.Invoke();
                        currentIpAddr = srcAddr;
                        fileName = "logs\\LostArk_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";
                        loggedPacketCount = 0;
                        tcpReconstruction = new TcpReconstruction(ProcessPacket);
                    }
                }
                tcpReconstruction.ReassemblePacket(tcp);
            }
        }

        public void Dispose()
        {
            socket.Close();
            socket = null;
        }
    }
}
