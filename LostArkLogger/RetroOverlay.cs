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
using System.Diagnostics;
using Be.Timvw.Framework.ComponentModel;
using LostArkLogger;
using System.ComponentModel;
using System.Globalization;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using SharpPcap;
using SharpPcap.LibPcap;
using PacketDotNet;

namespace LostArkLogger
{
    public partial class RetroOverlay : Form
    {
        IPEndPoint endPoint;

        StringBuilder log = new StringBuilder();
        private Stopwatch watch = new Stopwatch();
        private SortableBindingList<DamageMeterRow> AttackerList = new SortableBindingList<DamageMeterRow>();

        private float totalDamage;
        private float topDmg;

        public RetroOverlay()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Size.Width == 0 || Properties.Settings.Default.Size.Height == 0)
            {

            }
            else
            {
                this.WindowState = Properties.Settings.Default.State;

                // we don't want a minimized window at startup
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;

                this.Location = Properties.Settings.Default.Location;
                this.Size = Properties.Settings.Default.Size;
                this.Opacity = Properties.Settings.Default.OpacitySetting;
                this.trackBarMenuItem1.Value = (int)Math.Ceiling(this.Opacity * 100);
                this.TopMost = Properties.Settings.Default.OnTop;
                this.alwaysOnTopToolStripMenuItem.Checked = Properties.Settings.Default.OnTop;
            }

            // data grid style
            encounterDataGridView.DataSource = AttackerList;
            encounterDataGridView.Columns[1].HeaderText = "Damage";
            encounterDataGridView.Columns[2].HeaderText = "%";
            encounterDataGridView.Columns[3].HeaderText = "DPS";
            encounterDataGridView.Columns[4].HeaderText = "Max Hit";
            encounterDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            encounterDataGridView.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            encounterDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //encounterDataGridView.Columns[1].Resizable = DataGridViewTriState.False;
            /*
            encounterDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            encounterDataGridView.Columns[1].Width = 80;
            encounterDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            encounterDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            */
            encounterDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            encounterDataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            encounterDataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            encounterDataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            encounterDataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            encounterDataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            encounterDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(65, 93, 137);
            encounterDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            encounterDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            encounterDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            encounterDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            encounterDataGridView.RowsDefaultCellStyle.Font = new Font("Bahnschrift", 13, FontStyle.Regular, GraphicsUnit.Pixel);
            encounterDataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(90, 93, 107);
            encounterDataGridView.RowsDefaultCellStyle.ForeColor = Color.White;
            encounterDataGridView.BackgroundColor = Color.FromArgb(72, 74, 84);
            encounterDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(72, 74, 84);
            encounterDataGridView.EnableHeadersVisualStyles = false;

            foreach (DataGridViewColumn column in encounterDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            encounterDataGridView.Columns[1].DefaultCellStyle.Format = "N0";
            encounterDataGridView.Columns[2].DefaultCellStyle.Format = "P1";

            // double buffering
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            encounterDataGridView, new object[] { true });

            // other styles
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new MyColorTable());
            menuStrip1.BackColor = Color.FromArgb(65, 93, 137);
            menuStrip1.ForeColor = Color.White;
            menuStrip1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            //TopMost = true;
            alwaysOnTopToolStripMenuItem.CheckOnClick = true;
            alwaysOnTopToolStripMenuItem.BackColor = Color.FromArgb(65, 93, 137);
            alwaysOnTopToolStripMenuItem.ForeColor = Color.White;
            alwaysOnTopToolStripMenuItem.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Pixel);

            trackBarMenuItem1.trackBar.Scroll += TrackBar_Scroll;
            trackBarMenuItem1.trackBar.AutoSize = false;
            trackBarMenuItem1.trackBar.Height = 20;
            opacityToolStripMenuItem.BackColor = Color.FromArgb(65, 93, 137);
            opacityToolStripMenuItem.ForeColor = Color.White;
            opacityToolStripMenuItem.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Pixel);

            exportToolStripMenuItem.BackColor = Color.FromArgb(65, 93, 137);
            exportToolStripMenuItem.ForeColor = Color.White;
            exportToolStripMenuItem.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Pixel);

            timer1.Enabled = true;
            timer1.Interval = 10;
        }
        
        internal Parser sniffer;
        internal void AddSniffer(Parser s)
        {
            sniffer = s;
            sniffer.onDamageEvent += AddDamageEvent;
        }

        // main log writing to window
        void AddDamageEvent(LogInfo log)
        {
            if (log.Type == Entity.EntityType.Npc) return;
            SortableBindingList<DamageMeterRow> updateList;
            // if we got new combat data, and we clicked reset, reset the meter
            if (!watch.IsRunning)
            {
                totalDamage = 0;
                updateList = new SortableBindingList<DamageMeterRow>();
                watch.Restart();
            }
            else
                updateList = new SortableBindingList<DamageMeterRow>(AttackerList.ToList());

            totalDamage += log.Damage; // adding to the total damage of the parser

            bool found = false;
            foreach (var attacker in updateList)
            {
                if (attacker.Name == log.Source)
                {
                    found = true;
                    attacker.totalDamage += log.Damage;
                    if (attacker.highestDamage < log.Damage)
                    {
                        attacker.highestDamage = log.Damage;
                        attacker.skillId = log.SkillName;
                    }
                }
                TimeSpan timeElapsed = (DateTime.UtcNow - attacker.dmgStart);
                double timeInSeconds = Math.Ceiling(timeElapsed.TotalSeconds);
                attacker.dmgPerSec = (long)(attacker.totalDamage / timeInSeconds);
                attacker.DamagePercent = attacker.totalDamage / totalDamage;
            }

            if (!found)
            {
                var row = new DamageMeterRow
                {
                    Name = log.Source,
                    totalDamage = log.Damage,
                    highestDamage = log.Damage,
                    skillId = log.SkillName,
                    DamagePercent = log.Damage / totalDamage,
                    dmgStart = DateTime.UtcNow,
                    dmgPerSec = (long)(log.Damage / 1)
                };
                updateList.Add(row);
            }

            // sorting the list as descending
            AttackerList = new SortableBindingList<DamageMeterRow>(updateList.OrderByDescending(x => x.DamagePercent).ToList());
            topDmg = AttackerList[0].totalDamage;

            this.InvokeIfRequired((MethodInvoker)delegate
            {
                // total damage display
                label2.Text = $"- {totalDamage:n0} DMG";
                encounterDataGridView.DataSource = AttackerList;
            });
        }

        // form closing
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.State = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                // save location and size if the state is normal
                Properties.Settings.Default.Location = this.Location;
                Properties.Settings.Default.Size = this.Size;
                Properties.Settings.Default.OpacitySetting = (double)trackBarMenuItem1.Value / 100;
                Properties.Settings.Default.OnTop = alwaysOnTopToolStripMenuItem.Checked;
            }
            else
            {
                // save the RestoreBounds if the form is minimized or maximized!
                Properties.Settings.Default.Location = this.RestoreBounds.Location;
                Properties.Settings.Default.Size = this.RestoreBounds.Size;
                Properties.Settings.Default.OpacitySetting = (double)trackBarMenuItem1.Value / 100;
                Properties.Settings.Default.OnTop = alwaysOnTopToolStripMenuItem.Checked;
            }

            // don't forget to save the settings
            Properties.Settings.Default.Save();
        }


        // timer tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            // updates time if stopwatch is running
            if (watch.IsRunning)
            {
                label1.Text = string.Format("{0:hh\\:mm\\:ss}", watch.Elapsed);
            }
        }

        // pressing of the reset button
        private void resetBttn_Click(object sender, EventArgs e)
        {
            if (watch.IsRunning)
            {
                watch.Stop();
            }
        }

        // always on top toggle
        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
        }

        // changing opacity
        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            Opacity = (double)trackBarMenuItem1.Value / 100;
            opacityIndicatorToolStripMenuItem.Text = trackBarMenuItem1.Value.ToString();
        }

        // copying log to cliboard
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list = new BindingList<DamageMeterRow>(AttackerList.OrderByDescending(x => x.DamageSum).ToList());
            var s = "";
            foreach (var a in list)
            {
                s += $"{a.Name} | {String.Format("{0:n0}", a.DamageSum)} dmg | {a.DamagePercent.ToString("P1", CultureInfo.CurrentCulture)} contrib | Max: {a.MaxHit}\n";
            }
            if (s != "")
            {
                s = s.Remove(s.Length - 1);
                var result = s;
                Clipboard.SetText(result);
            }
        }
    }
}
