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
        Parser sniffer;
        Overlay overlay;
        RetroOverlay retro;
        public MainWindow()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Oodle.Init();
            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
            overlay = new Overlay();
            overlay.sniffer = sniffer;
            overlay.Show();
            sniffer = new Parser();
            sniffer.onPacketTotalCount += (int totalPacketCount) => {
                this.loggedPacketCountLabel.Text = "Logged Packets : " + totalPacketCount;
            };
            if (sniffer.monitorType == Machina.Infrastructure.NetworkMonitorType.WinPCap)
                this.sniffModeLabel.Text = "winpcap";
            overlay.AddSniffer(sniffer);

            /*
            // RetroOverlay
            retro = new RetroOverlay();
            retro.sniffer = sniffer;
            retro.Show();
            sniffer = new Parser(this);
            retro.AddSniffer(sniffer);
            */
        }

        private void weblink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/shalzuth/LostArkLogger");
        }

        private void overlayEnabled_CheckedChanged(object sender, EventArgs e)
        {
            overlay.Visible = overlayEnabled.Checked;
        }

        private void logEnabled_CheckedChanged(object sender, EventArgs e)
        {
            this.sniffer.enableLogging = logEnabled.Checked;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            overlay.Invalidate();
        }
    }
}
