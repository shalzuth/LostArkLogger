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
using System.Text.RegularExpressions;

namespace LostArkLogger
{
    public partial class MainWindow : Form
    {
        Sniffer sniffer;
        Overlay overlay;
        public MainWindow()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            Oodle.Init();
            overlay = new Overlay();
            overlay.sniffer = sniffer;
            overlay.Show();
            sniffer = new Sniffer(this);
            overlay.AddSniffer(sniffer);
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
            //sniffer.log
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            overlay.Damages.Clear();
            overlay.Invalidate();
        }
        private void CopyBtn_Click(object sender, EventArgs e) {
            var Damages = overlay.Damages;

            if(Damages.Count == 0) return;
            var totalDamage = Damages.Values.Sum(b => (Single)b);
            var orderedDamages = Damages.OrderByDescending(b => b.Value);
            string logMsg = "LostArkLogger ";

            for(var i = 0; i < Damages.Count && i < 8; i++) {
                var playerDmg = orderedDamages.ElementAt(i);
                var formattedDmg = overlay.FormatNumber(playerDmg.Value) + " (" + (100f * playerDmg.Value / totalDamage).ToString("#.0") + "%)";
                var playerName = playerDmg.Key;
                playerName = Regex.Replace(playerName, @"\(.*\)", "");
                playerName = (playerName.Length <= 6 ? playerName : playerName.Substring(0, 6) + ".");
                logMsg += playerName + " " + formattedDmg;
                if(i < Damages.Count - 1) logMsg += ", ";
            }

            System.Windows.Forms.Clipboard.SetText(logMsg);
            Console.WriteLine(logMsg);
        }
    }
}
