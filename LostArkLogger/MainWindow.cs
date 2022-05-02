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
    public partial class MainWindow : Form
    {
        Socket socket;
        Byte[] packetBuffer = new Byte[0x10000]; //Packet Buffer

        public MainWindow()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            OodleInit();
            FirewallManager.AllowFirewall();
            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            socket.Bind(new IPEndPoint(GetLocalIPAddress(), 0));
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);
            socket.IOControl(IOControlCode.ReceiveAll, BitConverter.GetBytes(1), BitConverter.GetBytes(0));
            socket.BeginReceive(packetBuffer, 0, packetBuffer.Length, SocketFlags.None, new AsyncCallback(OnReceive), null);
        }
        public static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            //var activeDevice = NetworkInterface.GetAllNetworkInterfaces().First(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback);
            //var activeDeviceIpProp = activeDevice.GetIPProperties().UnicastAddresses.Select(a => a.Address.AddressFamily == AddressFamily.InterNetwork);
            var ipAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            return ipAddress;
        }
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
        public Dictionary<UInt64, UInt64> ProjectileOwner = new Dictionary<UInt64, UInt64>();
        public Dictionary<UInt64, String> IdToName = new Dictionary<UInt64, String>();
        public Dictionary<String, String> NameToClass = new Dictionary<String, String>();
        int loggedPacketCount = 0;
        UInt32 currentIpAddr = 0xdeadbeef;
        string fileName;
        bool combatFound = false;
        Byte[] fragmentedPacket = new Byte[0];
        Byte[] XorTable = Convert.FromBase64String("lhs9nuO0tqJVKLVNYzeXhClXrz44CESmP/HiNeeIfO6kLCEiwJEPkE7G9uEA0mv+AV0ET2aUgka30RFvL229aQbV9bvI+JtFcxRLHMKTlWFcs3Qtz0BCFaOAuF4uq3oK140JeyAfB6pIwR3e97o7jJIQvhmnyo6JnDFD3DDqEw7/hRc2zYflUXhU5J1QpW6B9DN9TIa8AypWEtZ++iNJ78vD/Dx16cRost8W05kYmOgmauuLOVrzxUry0INHU4rOcXfM8PlgKzpYYiSaC+DYZ/u5/VlSrqGgZDTUW92tv2wC2agncrDHBdvmDSUeMrGs7XCpeX9BGsmfZezaX48Mdg==");
        void Xor(byte[] data, int seed, byte[] xorKey)
        {
            for (int i = 0; i < data.Length; i++) data[i] = (byte)(data[i] ^ xorKey[seed++ % xorKey.Length]);
        }
        [DllImport("oo2net_9_win64")] static extern bool OodleNetwork1UDP_Decode(byte[] state, byte[] shared, byte[] comp, int compLen, byte[] raw, int rawLen);
        [DllImport("oo2net_9_win64")] static extern bool OodleNetwork1UDP_State_Uncompact(byte[] state, byte[] compressorState);
        [DllImport("oo2net_9_win64")] static extern void OodleNetwork1_Shared_SetWindow(byte[] data, int length, byte[] data2, int length2);
        [DllImport("oo2net_9_win64")] static extern int OodleNetwork1UDP_State_Size();
        [DllImport("oo2net_9_win64")] static extern int OodleNetwork1_Shared_Size(int bits);
        Byte[] oodleState;
        Byte[] oodleSharedDict;
        void OodleInit()
        {
            while (!File.Exists("oo2net_9_win64.dll"))
            {
                if (File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Lost Ark\Binaries\Win64\oo2net_9_win64.dll"))
                {
                    File.Copy(@"C:\Program Files (x86)\Steam\steamapps\common\Lost Ark\Binaries\Win64\oo2net_9_win64.dll", "oo2net_9_win64.dll");
                    continue;
                }
                if (MessageBox.Show("please copy oo2net_9_win64 from LostArk directory to current directory", "Missing DLL") != DialogResult.OK) return;
            }
            var payload = ObjectSerialize.Decompress(Properties.Resources.oodle_state);
            var dict = payload.Skip(0x20).Take(0x800000).ToArray();
            var compressorSize = BitConverter.ToInt32(payload, 0x18);
            var compressorState = payload.Skip(0x20).Skip(0x800000).Take(compressorSize).ToArray();
            var stateSize = OodleNetwork1UDP_State_Size();
            oodleState = new Byte[stateSize];
            if (!OodleNetwork1UDP_State_Uncompact(oodleState, compressorState)) throw new Exception("oodle init fail");
            oodleSharedDict = new Byte[OodleNetwork1_Shared_Size(0x13) * 2];
            OodleNetwork1_Shared_SetWindow(oodleSharedDict, 0x13, dict, 0x800000);
        }
        Byte[] OodleDecompress(Byte[] decompressed)
        {
            var oodleSize = BitConverter.ToInt32(decompressed, 0);
            var payload = decompressed.Skip(4).ToArray();
            var tempPayload = new Byte[oodleSize];
            if (!OodleNetwork1UDP_Decode(oodleState, oodleSharedDict, payload, payload.Length, tempPayload, oodleSize))
            {
                OodleInit();
                if (!OodleNetwork1UDP_Decode(oodleState, oodleSharedDict, payload, payload.Length, tempPayload, oodleSize))
                    throw new Exception("oodle decompress fail");
            }
            return tempPayload;
        }
        StringBuilder log = new StringBuilder();
        void ProcessPacket(List<Byte> data)
        {
            var packets = data.ToArray();
            if (BitConverter.ToUInt16(data.ToArray(), 2) == 0xacdb) combatFound = true;
            var packetWithTimestamp = BitConverter.GetBytes(DateTime.UtcNow.ToBinary()).ToArray().Concat(data);
            loggedPacketCount++;
            loggedPacketCountLabel.Text = "Logged Packets : " + loggedPacketCount;
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
                if (packets[5] != 1 || 6 > packets.Length || packetSize < 7) return;
                var payload = packets.Skip(6).Take(packetSize - 6).ToArray();
                Xor(payload, (UInt16)opcode, XorTable);
                if (packets[4] == 3) payload = OodleDecompress(payload).Skip(16).ToArray();
                if (opcode == OpCodes.PKTCombatStatusNotify)
                    combatFound = true;
                else if (opcode == OpCodes.PKTNewProjectile)
                    ProjectileOwner[BitConverter.ToUInt64(payload, 26)] = BitConverter.ToUInt64(payload, 26 + 8);
                else if (opcode == OpCodes.PKTNewNpc)
                {
                    var npcName = Npc.GetNpcName(BitConverter.ToUInt32(payload, 6 + 16 + 15));
                    IdToName[BitConverter.ToUInt64(payload, 6 + 16 + 7)] = npcName;
                }
                else if (opcode == OpCodes.PKTNewPC)
                {
                    var pc = new PKTNewPC(payload);
                    var pcClass = Npc.GetPcClass(pc.ClassId);
                    if (!NameToClass.ContainsKey(pc.Name)) NameToClass[pc.Name] = pcClass + (NameToClass.ContainsValue(pcClass) ? (" - " + Guid.NewGuid().ToString().Substring(0, 4)) : "");
                    IdToName[pc.PlayerId] = NameToClass[pc.Name];
                }
                else if (opcode == OpCodes.PKTInitEnv)
                {
                    var pc = new PKTInitEnv(payload);
                    IdToName[pc.PlayerId] = "MyTempName";
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
                            var ownerName = IdToName.ContainsKey(ownerId) ? IdToName[ownerId] : ownerId.ToString("X");
                            if (ownerName == "MyTempName")
                            {
                                var className = Skill.GetClassFromSkill(damage.SkillId);
                                if (className != "UnknownClass")
                                {
                                    ownerName = IdToName[ownerId] = className + (IdToName.ContainsValue(className) ? (" - " + Guid.NewGuid().ToString().Substring(0, 4)) : "");
                                    log = log.Replace("MyTempName", IdToName[ownerId]);
                                }
                            }
                            var targetName = IdToName.ContainsKey(dmgEvent.TargetId) ? IdToName[dmgEvent.TargetId] : dmgEvent.TargetId.ToString("X");
                            log.AppendLine(DateTime.Now.ToString("yy:MM:dd:HH:mm:ss.f") + "," + ownerName + "," + targetName + "," + skillName + "," + dmgEvent.Damage + "," + (((dmgEvent.FlagsMaybe & 0x81) > 0) ? "1" : "0") + "," + (((dmgEvent.FlagsMaybe & 0x10) > 0) ? "1" : "0") + "," + (((dmgEvent.FlagsMaybe & 0x20) > 0) ? "1" : "0"));
                            Console.WriteLine(DateTime.Now.ToString("yy:MM:dd:HH:mm:ss.f") + "," + ownerName + "," + targetName + "," + skillName + "," + dmgEvent.Damage + "," + (((dmgEvent.FlagsMaybe & 0x81) > 0) ? "1" : "0") + "," + (((dmgEvent.FlagsMaybe & 0x10) > 0) ? "1" : "0") + "," + (((dmgEvent.FlagsMaybe & 0x20) > 0) ? "1" : "0"));
                        }
                    }
                }
                else if (opcode == OpCodes.PKTAbnormalMoveNotify)
                {
                    // normal mobs when skills make them move. not needed for boss tracking, since guardians don't get moved by abilities. this will show more damage taken by players
                }
                if (packets.Length < packetSize) throw new Exception("bad packet maybe");
                packets = packets.Skip(packetSize).ToArray();
            }
        }
        TcpReconstruction tcpReconstruction;
        void EndCapture()
        {
            if (combatFound)
            {
                combatFound = false;
                File.WriteAllText(fileName, log.ToString());
            }
            currentIpAddr = 0xdeadbeef;
        }
        void Device_OnPacketArrival(Byte[] bytes)
        {
            if ((ProtocolType)bytes[9] == ProtocolType.Tcp) // 6
            {
                var tcp = new PacketDotNet.TcpPacket(new PacketDotNet.Utils.ByteArraySegment(bytes.Skip(20).ToArray()));
                if (tcp.SourcePort != 6040) return; // this filter should be moved up before parsing to TcpPacket for performance
                var srcAddr = BitConverter.ToUInt32(bytes, 12);
                if (srcAddr != currentIpAddr)
                {
                    if (tcp.PayloadData.Length > 4 && (OpCodes)BitConverter.ToUInt16(tcp.PayloadData, 2) == OpCodes.PKTAuthTokenResult && tcp.PayloadData[0] == 0x1e)
                    {
                        EndCapture();
                        currentIpAddr = srcAddr;
                        fileName = "logs\\LostArk_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";
                        log = new StringBuilder();
                        loggedPacketCount = 0;
                        tcpReconstruction = new TcpReconstruction(ProcessPacket);
                    }
                    else return;
                }
                tcpReconstruction.ReassemblePacket(tcp);
            }
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            socket.Close();
            socket = null;
        }

        private void weblink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/shalzuth/LostArkLogger");
        }

        private void endRunButton_Click(object sender, EventArgs e)
        {
            EndCapture();
        }
    }
}
