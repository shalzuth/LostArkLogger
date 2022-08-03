using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using LostArkLogger.Utilities;
using System.ComponentModel;

namespace LostArkLogger
{
    public partial class MainWindow : Form, INotifyPropertyChanged
    {
        Parser sniffer;
        Overlay overlay;
        private int _packetCount;

        public event PropertyChangedEventHandler PropertyChanged;

        public string PacketCount
        {
            get { return "Logged Packets: " + _packetCount; }
        }

        public MainWindow()
        {
            InitializeComponent();
            versionLabel.Text = "v" + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            Oodle.Init();
            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
            sniffer = new Parser();
            sniffer.onPacketTotalCount += (int totalPacketCount) =>
            {
                _packetCount = totalPacketCount;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PacketCount)));
            };
            regionSelector.DataSource = Enum.GetValues(typeof(Region));
            regionSelector.SelectedIndex = (int)Properties.Settings.Default.Region;
            regionSelector.SelectedIndexChanged += new EventHandler(regionSelector_SelectedIndexChanged);
            loggedPacketCountLabel.Text = "Logged Packets : 0";
            loggedPacketCountLabel.DataBindings.Add("Text", this, nameof(PacketCount));
            displayName.Checked = Properties.Settings.Default.DisplayNames;
            autoUpload.Checked = Properties.Settings.Default.AutoUpload;
            displayName.CheckedChanged += new EventHandler(displayName_CheckedChanged);
            autoUpload.CheckedChanged += new EventHandler(autoUpload_CheckedChanged);
            //sniffModeCheckbox.Checked = Properties.Settings.Default.Npcap;
            overlay = new Overlay();
            overlay.AddSniffer(sniffer);
            overlay.Show();
        }

        private void weblink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/shalzuth/LostArkLogger");
        }

        private void overlayEnabled_CheckedChanged(object sender, EventArgs e)
        {
            overlay.Visible = overlayEnabled.Checked;
        }

        private void debugLog_CheckedChanged(object sender, EventArgs e)
        {
            Logger.debugLog = debugLog.Checked;
        }

        private void checkUpdate_Click(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers["User-Agent"] = "LostArkLogger";
                var json = wc.DownloadString(@"https://api.github.com/repos/shalzuth/LostArkLogger/releases/latest");
                var version = json.Substring(json.IndexOf("tag_name") + 11);
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
        private void sniffModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            this.sniffModeCheckbox.Enabled = false;
            this.sniffer.use_npcap = sniffModeCheckbox.Checked;
            this.sniffer.InstallListener();
            // This will unset the checkbox if it fails to initialize
            this.sniffModeCheckbox.Checked = this.sniffer.use_npcap;
            this.sniffModeCheckbox.Enabled = true;
            Properties.Settings.Default.Npcap = sniffModeCheckbox.Checked;
            Properties.Settings.Default.Save();
        }

        private void regionSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Region = (Region)Enum.Parse(typeof(Region), regionSelector.Text);
            //Properties.Settings.Default.Save();
            //System.Diagnostics.Process.Start(AppDomain.CurrentDomain.FriendlyName);
            //Environment.Exit(0);
        }

        private void displayName_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DisplayNames = displayName.Checked;
            Properties.Settings.Default.Save();

        }

        private void autoUpload_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoUpload = autoUpload.Checked;
            Properties.Settings.Default.Save();

        }
    }
}
