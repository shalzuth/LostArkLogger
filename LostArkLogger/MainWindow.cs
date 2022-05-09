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
            versionLabel.Text = "v" + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            Oodle.Init();
            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
            sniffer = new Parser();
            sniffer.onPacketTotalCount += (int totalPacketCount) => {
                this.loggedPacketCountLabel.Text = "Logged Packets : " + totalPacketCount;
            };
            overlay = new Overlay();
            overlay.AddSniffer(sniffer);
            overlay.Show();

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

        private void debugLog_CheckedChanged(object sender, EventArgs e)
        {
            sniffer.debugLog = debugLog.Checked;
        }

        private void checkUpdate_Click(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers["User-Agent"] = "LostArkLogger";
                var json = wc.DownloadString(@"https://api.github.com/repos/shalzuth/LostArkLogger/releases/latest");
                var version = json.Substring(json.IndexOf("tag_name") + 12);
                version = version.Substring(0, version.IndexOf("\""));
                if (version == System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString()) MessageBox.Show("Current version is up to date : " + version, "Version Info");
                else
                {
                    var exeUrl = json.Substring(json.IndexOf("browser_download_url") + 23);
                    exeUrl = exeUrl.Substring(0, exeUrl.IndexOf("\""));
                    var curFileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;
                    if (File.Exists(curFileName + ".old")) File.Delete(curFileName + ".old");
                    File.Move(curFileName, curFileName + ".old"); // need to delete this old breadcrumb elegantly. maybe on app start. not going to solve right now.
                    wc.DownloadFile(exeUrl, curFileName);
                    System.Diagnostics.Process.Start(curFileName);
                    Environment.Exit(0);
                }
            }
        }
    }
}
