using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LostArkLogger
{
    public partial class Overlay : Form
    {
        enum OverlayType {
            TotalDamage,
            SkillDamage,
            EntityDamage
        }
        public Overlay()
        {
            InitPens();
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
        }
        internal void AddSniffer(Parser s)
        {
            sniffer = s;
            sniffer.onDamageEvent += AddDamageEvent;
            sniffer.onNewZone += NewZone;
        }
        public void NewZone()
        {
            Events = new ConcurrentBag<LogInfo>();
            Damages.Clear();
            TotalDamages.Clear();
            SkillDmg.Clear();
            EntityDmg.Clear();
            EntityNames.Clear();
            targetComboBox.Items.Clear();
            targetComboBox.Items.Add("Total damages");
            targetComboBox.SelectedIndex = 0;
            targetComboBox.TabIndex = 0;

            SwitchOverlay(OverlayType.TotalDamage);
        }
        private DateTime startCombatTime = DateTime.Now;
        ConcurrentBag<LogInfo> Events = new ConcurrentBag<LogInfo>();
        private OverlayType currentOverlay = OverlayType.TotalDamage;
        string focused = String.Empty;
        public ConcurrentDictionary<string, string> EntityNames = new ConcurrentDictionary<string, string>();
        public ConcurrentDictionary<string, UInt64> Damages = new ConcurrentDictionary<string, ulong>();
        public ConcurrentDictionary<string, UInt64> TotalDamages = new ConcurrentDictionary<string, ulong>();
        public ConcurrentDictionary<string, ConcurrentDictionary<string, UInt64>> SkillDmg = new ConcurrentDictionary<string, ConcurrentDictionary<string, ulong>>();
        public ConcurrentDictionary<string, ConcurrentDictionary<string, UInt64>> EntityDmg = new ConcurrentDictionary<string, ConcurrentDictionary<string, ulong>>();
        Font font = new Font("Helvetica", 10);
        Font comboFont = new Font("Helvetica", 9);
        Font refreshFont = new Font("Arial", 12);
        void AddDamageEvent(LogInfo log)
        {
            if(TotalDamages.Count == 0) startCombatTime = DateTime.Now;
            Events.Add(log);

            var ownerId = log.OwnerId.ToString("X");
            var targetId = log.TargetId.ToString("X");

            if(!EntityNames.ContainsKey(ownerId))
                EntityNames[ownerId] = log.Source;
            if(!EntityNames.ContainsKey(targetId))
                EntityNames[targetId] = log.Destination;

            if (!TotalDamages.ContainsKey(ownerId)) TotalDamages[ownerId] = 0;
            TotalDamages[ownerId] += log.Damage;

            if(log.Type == Entity.EntityType.Player) {
                if(!SkillDmg.ContainsKey(ownerId))
                    SkillDmg[ownerId] = new ConcurrentDictionary<string, ulong>();
                if(!SkillDmg[ownerId].ContainsKey(log.SkillName))
                    SkillDmg[ownerId][log.SkillName] = 0;
                SkillDmg[ownerId][log.SkillName] += log.Damage;

                if(!EntityDmg.ContainsKey(targetId)) {
                    targetComboBox.Items.Add(IdToName(targetId));
                    EntityDmg[targetId] = new ConcurrentDictionary<string, ulong>();
                }
                if(!EntityDmg[targetId].ContainsKey(ownerId))
                    EntityDmg[targetId][ownerId] = 0;
                EntityDmg[targetId][ownerId] += log.Damage;
            }


            SwitchOverlay(currentOverlay);
        }
        internal Parser sniffer;
        List<Brush> brushes = new List<Brush>();
        Brush black = new SolidBrush(Color.White);
        void InitPens()
        {
            String[] colors = {"#3366cc", "#dc3912", "#ff9900", "#109618", "#990099", "#0099c6", "#dd4477", "#66aa00", "#b82e2e", "#316395", "#994499", "#22aa99", "#aaaa11", "#6633cc", "#e67300", "#8b0707", "#651067", "#329262", "#5574a6", "#3b3eac", "#b77322", "#16d620", "#b91383", "#f4359e", "#9c5935", "#a9c413", "#2a778d", "#668d1c", "#bea413", "#0c5922", "#743411" };
            foreach(var color in colors) brushes.Add(new SolidBrush(ColorTranslator.FromHtml(color)));
        }
        int barHeight = 20;
        public static string FormatNumber(UInt64 n) // https://stackoverflow.com/questions/30180672/string-format-numbers-to-millions-thousands-with-rounding
        {
            if (n < 1000) return n.ToString();
            if (n < 10000) return String.Format("{0:#,.##}K", n - 5);
            if (n < 100000) return String.Format("{0:#,.#}K", n - 50);
            if (n < 1000000) return String.Format("{0:#,.}K", n - 500);
            if (n < 10000000) return String.Format("{0:#,,.##}M", n - 5000);
            if (n < 100000000) return String.Format("{0:#,,.#}M", n - 50000);
            if (n < 1000000000) return String.Format("{0:#,,.}M", n - 500000);
            return String.Format("{0:#,,,.##}B", n - 5000000);
        }
        public Rectangle GetSpriteLocation(int i)
        {
            var imageSize = 64;
            var x = i % 16;
            var y = i / 16;
            return new Rectangle(x * imageSize, y * imageSize, imageSize, imageSize);
        }
        public String[] ClassIconIndex = { "Destroyer", "unk", "Arcana", "Berserker", "Wardancer", "Deadeye", "MartialArtist", "Gunlancer", "Gunner", "Scrapper", "Mage", "Summoner", "Warrior",
         "Soulfist", "Sharpshooter", "Artillerist", "Bard", "Glavier", "Assassin", "Deathblade", "Shadowhunter", "Paladin", "Scouter", "Reaper", "FemaleGunner", "Gunslinger", "MaleMartialArtist", "Striker", "Sorceress" };
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

            var title = "DPS Meter";
            if(currentOverlay == OverlayType.SkillDamage) title = "Damage details - " + IdToName(focused);

            Brush backColor = brushes[10];
            if(currentOverlay == OverlayType.SkillDamage) backColor = brushes[12];
            e.Graphics.FillRectangle(backColor, 0, 0, Size.Width, barHeight);

            targetComboBox.BackColor = ((SolidBrush)backColor).Color;
            targetComboBox.ListBackColor = ((SolidBrush)backColor).Color;
            targetComboBox.ForeColor = Color.White;
            targetComboBox.Font = comboFont;
            targetComboBox.Location = new Point(e.Graphics.MeasureString(title, font).ToSize().Width + 15, 0);
            targetComboBox.ListBackColor = ((SolidBrush)backColor).Color;
            targetComboBox.MinimumSize = new Size(10, 10);
            targetComboBox.Size = new Size(120, 20);

            var titleBar = e.Graphics.MeasureString(title, font);
            var heightBuffer = (barHeight - titleBar.Height) / 2;
            e.Graphics.DrawString(title, font, black, 5, heightBuffer);
            e.Graphics.DrawString("⟳", refreshFont, black, Size.Width - 20, 0);
            if (Damages.Count == 0) return;
            var maxDamage = Damages.Max(b => b.Value);
            var totalDamage = Damages.Values.Sum(b=>(Single)b);
            var orderedDamages = Damages.OrderByDescending(b => b.Value);
            for (var i = 0; i < Damages.Count && i < 8; i++)
            {
                var elapsed = (DateTime.Now - startCombatTime).TotalSeconds;
                var playerDmg = orderedDamages.ElementAt(i);
                var barWidth = ((Single)playerDmg.Value / maxDamage) * Size.Width;
                var valueName = IdToName(playerDmg.Key);
                if (barWidth < .3f) continue;
                
                var dps = FormatNumber((ulong)(playerDmg.Value / elapsed));
                var formattedDmg = FormatNumber(playerDmg.Value) + " (" + dps + ", " + (100f * playerDmg.Value / totalDamage).ToString("#.0") + "%)";
                var nameOffset = 0;
                if (valueName.Contains("("))
                {
                    var className = valueName.Substring(valueName.IndexOf("(") + 1);
                    className = className.Substring(0, className.IndexOf(")"));
                    e.Graphics.FillRectangle(brushes[Array.IndexOf(ClassIconIndex, className)], 0, (i + 1) * barHeight, barWidth, barHeight);
                    e.Graphics.DrawImage(Properties.Resources.class_symbol_0, new Rectangle(2, (i + 1) * barHeight + 2, barHeight - 4, barHeight - 4), GetSpriteLocation(Array.IndexOf(ClassIconIndex, className)), GraphicsUnit.Pixel);
                    nameOffset += 16;                    
                } else {
                    e.Graphics.FillRectangle(brushes[i], 0, (i + 1) * barHeight, barWidth, barHeight);
                }
                var edge = e.Graphics.MeasureString(formattedDmg, font);
                e.Graphics.DrawString(valueName, font, black, nameOffset + 5, (i + 1) * barHeight + heightBuffer);
                e.Graphics.DrawString(formattedDmg, font, black, Size.Width - edge.Width, (i + 1) * barHeight + heightBuffer);


            }
            ControlPaint.DrawSizeGrip(e.Graphics, BackColor, ClientSize.Width - 16, ClientSize.Height - 16, 16, 16);
        }

        [DllImport("user32.dll")] static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")] static extern bool ReleaseCapture();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private void Overlay_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left) {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

                /* Handle clic on refresh button */
                if((e.Location.X >= Size.Width - 20 && e.Location.X <= Size.Width - 5) && e.Location.Y <= 15)
                    NewZone();

                /* Handle clic on bar */
                var index = (int)Math.Floor(e.Location.Y / (float)barHeight - 1);
                if(index < 0 || index > Damages.Count) return;
                if(currentOverlay == OverlayType.TotalDamage) {
                    var focusId = Damages.OrderByDescending(b => b.Value).ElementAt(index).Key;
                    if(EntityNames.ContainsKey(focusId)) {
                        focused = focusId;
                        SwitchOverlay(OverlayType.SkillDamage);
                    }
                }
            }
            if(e.Button == MouseButtons.Right) {
                SwitchOverlay(OverlayType.TotalDamage);
            }
        }
        private string IdToName(string id) {
            return EntityNames.ContainsKey(id) ? EntityNames[id] : id;
        }
        private void SwitchOverlay(OverlayType type) {
            currentOverlay = type;
            targetComboBox.Visible = true;

            if(type == OverlayType.TotalDamage) {
                Damages = TotalDamages;
            }
            if(type == OverlayType.SkillDamage) {
                targetComboBox.Visible = false;
                if(SkillDmg.ContainsKey(focused))
                    Damages = SkillDmg[focused];
            }
            if(type == OverlayType.EntityDamage) {
                if(EntityDmg.ContainsKey(focused))
                    Damages = EntityDmg[focused];
            }

            Invalidate();
        }

        private void targetComboBox_OnSelectedIndexChanged(object sender, System.EventArgs e) {
            if(targetComboBox.SelectedIndex == -1) return;
            if(targetComboBox.SelectedIndex == 0) {
                SwitchOverlay(OverlayType.TotalDamage);
            } else {
                focused = EntityDmg.OrderBy(b => b.Key).ElementAt(targetComboBox.SelectedIndex - 1).Key;
                SwitchOverlay(OverlayType.EntityDamage);
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int wmNcHitTest = 0x84;
            const int htBottomLeft = 16;
            const int htBottomRight = 17;
            if (m.Msg == wmNcHitTest)
            {
                var x = (int)(m.LParam.ToInt64() & 0xFFFF);
                var y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                var pt = PointToClient(new Point(x, y));
                var clientSize = ClientSize;
                if (pt.X >= clientSize.Width - 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16)
                {
                    m.Result = (IntPtr)(IsMirrored ? htBottomLeft : htBottomRight);
                    return;
                }
            }
            base.WndProc(ref m);
        }

        public new void Dispose()
        {
            sniffer.onDamageEvent -= AddDamageEvent;
            sniffer.onNewZone -= NewZone;
            base.Dispose();
        }
    }
}
