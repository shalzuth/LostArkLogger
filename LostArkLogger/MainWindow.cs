using System;
using System.Windows.Forms;

namespace LostArkLogger
{
    public partial class MainWindow : Form
    {
        Sniffer sniffer;
        Overlay overlay;
        public MainWindow(bool use_npcap = false)
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

        public void InitNpcap()
        {
            sniffer.InitializeNPcap();
        }

        public void InitNetsh()
        {
            sniffer.InitializeNetSh();
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
    }
}
