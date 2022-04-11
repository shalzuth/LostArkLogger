using System;
using System.Collections.Generic;
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
            //UploadFile(@"LostArk_2022-04-11-13-51-52.pcap");
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
        bool combatFound = false;
        void ProcessPacket(List<Byte> data)
        {
            if (BitConverter.ToUInt16(data.ToArray(), 2) == 0xc966) combatFound = true;
            var packetWithTimestamp = BitConverter.GetBytes(DateTime.UtcNow.ToBinary()).ToArray().Concat(data);
            logger.Write(packetWithTimestamp.ToArray());
            loggedPacketCount++;
            loggedPacketCountLabel.Text = "Logged Packets : " + loggedPacketCount;
            if (BitConverter.ToUInt16(data.ToArray(), 2) == 0xc735) EndCapture();
        }
        TcpReconstruction tcpReconstruction;
        String baseUrl = "http://lostark.shalzuth.com/";
        //String baseUrl = "http://127.0.0.1/";
        void UploadFile(String fileName)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                try // ignore server failures
                {
                    var pcapBytes = File.ReadAllBytes(fileName);
                    var request = (HttpWebRequest)WebRequest.Create(baseUrl + "appupload2c");
                    //var request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1/appupload");
                    request.Method = "POST";
                    request.ContentType = "application/octet-stream";
                    request.ContentLength = pcapBytes.Length;
                    using (var stream = request.GetRequestStream()) stream.Write(pcapBytes, 0, pcapBytes.Length);
                    var response = (HttpWebResponse)request.GetResponse();
                    var logGuid = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    System.Diagnostics.Process.Start(baseUrl + "log/" + logGuid);
                    var combatLog = new WebClient().DownloadString(baseUrl + "download/" + logGuid);
                    File.WriteAllText(fileName.Replace(".pcap", ".log"), combatLog);
                    // remove old pcap and/or text??
                }
                catch (Exception ex) { }
            });
        }
        void EndCapture()
        {
            if (logger != null)
            {

                logger.Close();
                logger = null;
                if (!combatFound) File.Delete(fileName);
            }
            if (combatFound && autoupload.Checked)
            {
                UploadFile(fileName);
                combatFound = false;
            }
            currentIpAddr = "";
        }
        void Device_OnPacketArrival(object s, PacketCapture e)
        {
            var p = Packet.ParsePacket(e.GetPacket().LinkLayerType, e.GetPacket().Data);
            var tcp = p.Extract<TcpPacket>();
            if (tcp.PayloadData.Length == 0) return;

            if ((tcp.ParentPacket as IPPacket).SourceAddress.ToString() != currentIpAddr)
            {
                if (BitConverter.ToUInt32(tcp.PayloadData, 0) == 0xccad001e)
                {
                    EndCapture();
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
