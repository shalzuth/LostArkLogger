using LostArkLogger.Packets;
using SharpPcap;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace LostArkLogger
{
    internal class Sniffer : IDisposable
    {
        Socket socket;
        Byte[] packetBuffer = new Byte[0x10000];
        MainWindow main;
        public Action newZone;
        public Action<LogInfo> addDamageEvent;
        public BlockingCollection<PacketBuff> packetContainer = new BlockingCollection<PacketBuff>();
        public List<OpCodes> validOpcodes = new List<OpCodes> {
            OpCodes.PKTNewNpc,
            OpCodes.PKTSkillDamageNotify,
            OpCodes.PKTNewPC,
            OpCodes.PKTInitEnv,
            OpCodes.PKTNewProjectile
        };

        public Sniffer(MainWindow m)
        {
            main = m;
            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
        }

        public void InitializeNetSh()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            socket.Bind(new IPEndPoint(GetLocalIPAddress(), 6040));
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);
            socket.IOControl(IOControlCode.ReceiveAll, BitConverter.GetBytes(1), BitConverter.GetBytes(0));
            socket.BeginReceive(packetBuffer, 0, packetBuffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
            Task.Run(() =>
            {
                while (!packetQueue.IsCompleted)
                {
                    if (packetQueue.TryTake(out Byte[] packet))
                    {
                        Device_OnPacketArrival(packet);
                    }

                    Thread.Sleep(5);
                }
            });
        }

        public void InitializeNPcap()
        {
            // clear overlay
            newZone?.Invoke();

            ILiveDevice device = null;
            IPAddress localIP;
            IPEndPoint endPoint;
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                s.Connect("8.8.8.8", 65530);
                endPoint = s.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address;
            }

            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType != NetworkInterfaceType.Loopback && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork && ip.Address.ToString() == localIP.ToString())
                        {
                            device = device = CaptureDeviceList.Instance.First(i => i.Description == item.Description);
                            device.Open(DeviceModes.MaxResponsiveness, 250);
                            device.Filter = "tcp port 6040";
                            device.OnPacketArrival += new PacketArrivalEventHandler(onReceivePacket);
                            device.StartCapture();

                            Task.Run(() =>
                            {
                                while (!packetContainer.IsCompleted)
                                {
                                    if (packetContainer.TryTake(out PacketBuff packet))
                                    {
                                        ProcessPacket(packet);
                                    }

                                    Thread.Sleep(5);
                                }
                            });

                            return;
                        }
                    }
                }
            }

        }


        public Dictionary<UInt64, UInt64> ProjectileOwner = new Dictionary<UInt64, UInt64>();
        public Dictionary<UInt64, String> IdToName = new Dictionary<UInt64, String>();
        public Dictionary<String, String> NameToClass = new Dictionary<String, String>();
        Byte[] fragmentedPacket = new Byte[0];

        void ProcessPayload(OpCodes opcode, byte[] payload)
        {
            if (opcode == OpCodes.PKTNewProjectile)
            {
                ProjectileOwner[BitConverter.ToUInt64(payload, 4)] = BitConverter.ToUInt64(payload, 4 + 8);
            }
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
                        //AppendLog(log.ToString());
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
        }

        void ProcessPacket(PacketBuff buff)
        {
            var packet = buff.data;
            var opcode = (OpCodes)buff.opcode;
            var packetSize = buff.size;

            loggedPacketCount++;
            main.loggedPacketCountLabel.Text = "Logged Packets : " + loggedPacketCount;

            if (packet[5] != 1)
            {
                return;
            }

            var payload = packet.Skip(6).Take(packetSize - 6).ToArray();
            Xor.Cipher(payload, (UInt16)opcode);
            if (packet[4] == 3) payload = Oodle.Decompress(payload).Skip(16).ToArray();

            ProcessPayload(opcode, payload);
        }


        void ProcessPacket(List<Byte> data)
        {
            var packets = data.ToArray();
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
                if (packets[4] == 3) payload = Oodle.Decompress(payload).Skip(16).ToArray();

                // process payload
                ProcessPayload(opcode, payload);

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
        BlockingCollection<Byte[]> packetQueue = new BlockingCollection<Byte[]>();
        Byte[] fragmentedRead = new Byte[0];
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                var bytesRead = socket?.EndReceive(ar);
                if (bytesRead > 0)
                {
                    var packets = new Byte[(int)bytesRead];
                    Array.Copy(packetBuffer, packets, (int)bytesRead);
                    packetQueue.Add(packets);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //packetBuffer = new Byte[packetBuffer.Length];
            socket?.BeginReceive(packetBuffer, 0, packetBuffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), ar);
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
                    else return;
                }
                tcpReconstruction.ReassemblePacket(tcp);
            }
        }

        private object locker = new object();
        private void onReceivePacket(object sender, PacketCapture e)
        {
            var packet = PacketDotNet.Packet.ParsePacket(e.GetPacket().LinkLayerType, e.GetPacket().Data);
            var tcpPacket = packet.Extract<PacketDotNet.TcpPacket>();
            if (tcpPacket != null)
            {
                int srcPort = tcpPacket.SourcePort;
                if (srcPort == 6040)
                {
                    lock (locker)
                    {
                        byte[] bytes = packet.PayloadPacket.PayloadPacket.PayloadData;
                        while (true)
                        {
                            if (bytes.Length < 2)
                                break;

                            var len = BitConverter.ToUInt16(bytes.ToArray(), 0);
                            if (len <= 0 || bytes.Length < len)
                                break;

                            if (len > 0 && bytes.Length >= len)
                            {
                                var opcode = (OpCodes)BitConverter.ToUInt16(bytes.ToArray(), 2);
                                if (validOpcodes.Contains(opcode))
                                {
                                    var data = new PacketBuff()
                                    {
                                        data = bytes.Take(len).ToArray(),
                                        size = len,
                                        opcode = (UInt16)opcode
                                    };
                                    packetContainer.Add(data);
                                }

                                bytes = bytes.Skip(len).ToArray();
                            }
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            socket.Close();
            socket = null;
        }
    }
}
