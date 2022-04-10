using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using SharpPcap.LibPcap;
using SharpPcap;
using PacketDotNet;

namespace LostArkLogger
{
    public partial class MainWindow : Form
    {
        CaptureFileWriterDevice logger;
        LibPcapLiveDevice device;
        public MainWindow()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            var devices = CaptureDeviceList.Instance;
            var activeDevice = NetworkInterface.GetAllNetworkInterfaces().First(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback);
            foreach (PcapDevice dev in devices) deviceList.Items.Add(dev.Description);
            deviceList.SelectedItem = activeDevice.Description;
        }
        private void deviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            device?.StopCapture();
            device?.Close();

            device = LibPcapLiveDeviceList.Instance.First(i => i.Description == deviceList.SelectedItem.ToString());
            device.Open();
            device.Filter = "tcp port 6040";
            device.OnPacketArrival += Device_OnPacketArrival;
            device.StartCapture();
        }
        int loggedPacketCount = 0;
        string currentIpAddr = "";
        string fileName;
        void ProcessPacket(Byte[] data)
        {
            var packetWithTimestamp = BitConverter.GetBytes(DateTime.UtcNow.ToBinary()).ToArray().Concat(data);
            logger.Write(packetWithTimestamp.ToArray());
            loggedPacketCount++;
            loggedPacketCountLabel.Text = "Logged Packets : " + loggedPacketCount;
        }
        TcpReconstruction tcpReconstruction;
        void Device_OnPacketArrival(object s, PacketCapture e)
        {
            var p = Packet.ParsePacket(e.GetPacket().LinkLayerType, e.GetPacket().Data);
            var tcp = p.Extract<TcpPacket>();
            if (tcp.PayloadData.Length == 0) return;

            if ((tcp.ParentPacket as IPPacket).SourceAddress.ToString() != currentIpAddr)
            {
                if (BitConverter.ToUInt32(tcp.PayloadData, 0) == 0xccad001e)
                {
                    if (autoupload.Checked && logger != null)
                    {
                        logger.Close();
                        var pcapBytes = File.ReadAllBytes(fileName);
                        try // ignore server failures
                        {
                            var request = (HttpWebRequest)WebRequest.Create("http://52.180.146.231/appupload");
                            //var request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1/appupload");
                            request.Method = "POST";
                            request.ContentType = "application/octet-stream";
                            request.ContentLength = pcapBytes.Length;
                            using (var stream = request.GetRequestStream()) stream.Write(pcapBytes, 0, pcapBytes.Length);
                            var response = (HttpWebResponse)request.GetResponse();
                            var combatLog = new StreamReader(response.GetResponseStream()).ReadToEnd();
                            File.WriteAllText(fileName.Replace(".pcap", ".log"), combatLog);
                        }catch (Exception ex) { }
                    }
                    currentIpAddr = (tcp.ParentPacket as IPPacket).SourceAddress.ToString();
                    fileName = "LostArk_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".pcap";
                    logger = new CaptureFileWriterDevice(fileName, FileMode.Create);
                    logger.Open();
                    loggedPacketCount = 0;
                    tcpReconstruction = new TcpReconstruction(ProcessPacket);
                }
                else return;
            }
            tcpReconstruction.ReassemblePacket(tcp);
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            logger?.Close();
            device?.StopCapture();
            device?.Close();
        }

        private void weblink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/shalzuth/LostArkLogger");
        }
    }
}
