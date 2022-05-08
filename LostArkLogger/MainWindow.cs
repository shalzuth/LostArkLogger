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

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                mainNotifyIcon.Visible = false;
            }
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                mainNotifyIcon.Visible = true;
                mainNotifyIcon.ShowBalloonTip(1000);
                ShowInTaskbar = false;
            }
        }

        private void startMinimized_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StartMinimized = startMinimized.Checked;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.mainWindowSize.Width != 0 && Properties.Settings.Default.mainWindowSize.Height != 0)
            {
                Location = Properties.Settings.Default.mainWindowLocation;
                Size = Properties.Settings.Default.mainWindowSize;
            }

            if (Properties.Settings.Default.StartMinimized)
            {
                WindowState = FormWindowState.Minimized;
                Hide();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.mainWindowLocation = Location;
                Properties.Settings.Default.mainWindowSize = Size;
            }
            else
            {
                Properties.Settings.Default.mainWindowLocation = RestoreBounds.Location;
                Properties.Settings.Default.mainWindowSize = RestoreBounds.Size;
            }
            Properties.Settings.Default.Save();
        }
    }
}
