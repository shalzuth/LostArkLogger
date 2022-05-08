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
        enum OverlayType // need better state, suboverlay type/etc.
        {
            TotalDamage,
            SkillDamage,
            Counterattacks,
            Encounters,
            Other
        }
        OverlayType type = OverlayType.TotalDamage;
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
            sniffer.onCombatEvent += AddDamageEvent;
            sniffer.onNewZone += NewZone;
            encounter = sniffer.currentEncounter;
        }
        public void NewZone()
        {
            encounter = sniffer.currentEncounter;
            SwitchOverlay(OverlayType.TotalDamage);
        }
        private DateTime startCombatTime = DateTime.Now;
        private OverlayType currentOverlay = OverlayType.TotalDamage;
        Encounter encounter;
        Entity SubEntity;
        Font font = new Font("Helvetica", 10);
        void AddDamageEvent(LogInfo log)
        {
            Invalidate();
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
            i--;
            var imageSize = 64;
            var x = i % 17;
            var y = i / 17;
            return new Rectangle(x * imageSize, y * imageSize, imageSize, imageSize);
        }
        public String[] ClassIconIndex = { "start1", "Destroyer", "unk", "Arcana", "Berserker", "Wardancer", "Deadeye", "MartialArtist", "Gunlancer", "Gunner", "Scrapper", "Mage", "Summoner", "Warrior",
         "Soulfist", "Sharpshooter", "Artillerist", "dummyfill", "Bard", "Glavier", "Assassin", "Deathblade", "Shadowhunter", "Paladin", "Scouter", "Reaper", "FemaleGunner", "Gunslinger", "MaleMartialArtist", "Striker", "Sorceress" };
        public Pen pen = new Pen(Color.FromArgb(255, 255, 255, 255), 4) { StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor };
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            e.Graphics.FillRectangle(brushes[10], 0, 0, Size.Width, barHeight);

            var title = "DPS Meter";
            if (currentOverlay == OverlayType.SkillDamage) title = "Damage details - " + SubEntity.VisibleName;
            if (currentOverlay == OverlayType.Counterattacks) title = "Counterattacks";
            if (currentOverlay == OverlayType.Encounters) title = "Encounters";
            var titleBar = e.Graphics.MeasureString(title, font);
            var heightBuffer = (barHeight - titleBar.Height) / 2;
            e.Graphics.DrawString(title, font, black, 5, heightBuffer);

            if (currentOverlay == OverlayType.Encounters)
            {
                for (var i = 0; i < sniffer.Encounters.Count && i < 8; i++)
                {
                    e.Graphics.FillRectangle(brushes[i], 0, (i + 1) * barHeight, Size.Width, barHeight);
                    e.Graphics.DrawString(sniffer.Encounters.ElementAt(sniffer.Encounters.Count - i - 1).EncounterName, font, black, 5, (i + 1) * barHeight + heightBuffer);
                }
            }
            else
            {
                var rows = new Dictionary<String, UInt64>();
                if (currentOverlay == OverlayType.TotalDamage) rows = encounter.TopLevelDamage;
                else if (currentOverlay == OverlayType.Counterattacks) rows = encounter.Counterattacks;
                else if (currentOverlay == OverlayType.SkillDamage)
                {
                    rows = encounter.Infos.Where(i => i.SourceEntity == SubEntity).GroupBy(i => i.SkillId).Select(i => new KeyValuePair<String, UInt64>(i.Key.ToString(), (UInt64)i.Sum(j => (Single)j.Damage))).ToDictionary(x => x.Key, x => x.Value);
                }
                var elapsed = ((encounter.End == default(DateTime) ? DateTime.Now : encounter.End) - encounter.Start).TotalSeconds;
                var maxDamage = rows.Count == 0 ? 0 : rows.Max(b => b.Value);
                var totalDamage = rows.Values.Sum(b => (Single)b);
                var orderedDamages = rows.OrderByDescending(b => b.Value);
                for (var i = 0; i < rows.Count && i < 8; i++)
                {
                    var playerDmg = orderedDamages.ElementAt(i);
                    var rowText = playerDmg.Key;
                    var barWidth = ((Single)playerDmg.Value / maxDamage) * Size.Width;
                    if (barWidth < .3f) continue;
                    e.Graphics.FillRectangle(brushes[i], 0, (i + 1) * barHeight, barWidth, barHeight);
                    var dps = FormatNumber((ulong)(playerDmg.Value / elapsed));
                    var formattedDmg = FormatNumber(playerDmg.Value) + " (" + dps + ", " + (100f * playerDmg.Value / totalDamage).ToString("#.0") + "%)";
                    var nameOffset = 0;
                    if (rowText.Contains("("))
                    {
                        var className = rowText.Substring(rowText.IndexOf("(") + 1);
                        className = className.Substring(0, className.IndexOf(")"));
                        e.Graphics.DrawImage(Properties.Resources.class_symbol_0, new Rectangle(2, (i + 1) * barHeight + 2, barHeight - 4, barHeight - 4), GetSpriteLocation(Array.IndexOf(ClassIconIndex, className)), GraphicsUnit.Pixel);
                        nameOffset += 16;
                    }
                    if (currentOverlay == OverlayType.SkillDamage)
                    {
                        /*if (Skill.GetSkillIcon(uint.Parse(rowText), out String iconFile, out int iconIndex))
                        {
                            nameOffset += 16;
                            e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject(iconFile.ToLower()), new Rectangle(2, (i + 1) * barHeight + 2, barHeight - 4, barHeight - 4), GetSpriteLocation(iconIndex), GraphicsUnit.Pixel);
                        }*/
                        rowText = Skill.GetSkillName(uint.Parse(rowText));
                    }
                    var edge = e.Graphics.MeasureString(formattedDmg, font);
                    e.Graphics.DrawString(rowText, font, black, nameOffset + 5, (i + 1) * barHeight + heightBuffer);
                    e.Graphics.DrawString(formattedDmg, font, black, Size.Width - edge.Width, (i + 1) * barHeight + heightBuffer);
                }
            }
            ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(Size.Width - 50, barHeight / 4, 10, barHeight / 2));
            e.Graphics.DrawLine(pen, Size.Width - 30, barHeight / 2, Size.Width - 20, barHeight / 2);
            e.Graphics.DrawLine(pen, Size.Width - 5, barHeight / 2, Size.Width - 15, barHeight / 2);
            ControlPaint.DrawSizeGrip(e.Graphics, BackColor, ClientSize.Width - 16, ClientSize.Height - 16, 16, 16);
        }
        [DllImport("user32.dll")] static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")] static extern bool ReleaseCapture();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        void Overlay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

                var index = (int)Math.Floor(e.Location.Y / (float)barHeight - 1);
                if (index >= 0)// && index <= Damages.Count)
                {
                    if (currentOverlay == OverlayType.TotalDamage)
                    {
                        var entityName = encounter.TopLevelDamage.OrderByDescending(b => b.Value).ElementAt(index).Key;
                        SubEntity = encounter.Infos.First(i => i.SourceEntity.VisibleName == entityName).SourceEntity;
                        SwitchOverlay(OverlayType.SkillDamage);
                    }
                    if (currentOverlay == OverlayType.Encounters)
                    {
                        encounter = sniffer.Encounters.ElementAt(sniffer.Encounters.Count - index - 1);
                        SwitchOverlay(OverlayType.TotalDamage);
                    }
                }
                if (new Rectangle(Size.Width - 50, barHeight / 4, 10, barHeight / 2).Contains(e.Location)) SwitchOverlay(OverlayType.Encounters);
                if (new Rectangle(Size.Width - 30, 0, 10, barHeight).Contains(e.Location)) SwitchOverlay(false);
                if (new Rectangle(Size.Width - 15, 0, 10, barHeight).Contains(e.Location)) SwitchOverlay(true);
            }
            if (e.Button == MouseButtons.Right)
            {
                if (currentOverlay == OverlayType.SkillDamage)
                    SwitchOverlay(OverlayType.TotalDamage);
            }
        }
        void SwitchOverlay(bool progress) 
        {
            if (currentOverlay == OverlayType.TotalDamage)
            {
                if (progress) SwitchOverlay(OverlayType.Counterattacks);
                else SwitchOverlay(OverlayType.Counterattacks);
            }
            else if (currentOverlay == OverlayType.Counterattacks)
            {
                if (progress) SwitchOverlay(OverlayType.TotalDamage);
                else SwitchOverlay(OverlayType.TotalDamage);
            }
        }
        void SwitchOverlay(OverlayType type)
        {
            currentOverlay = type;

            Invalidate();
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
            sniffer.onCombatEvent -= AddDamageEvent;
            sniffer.onNewZone -= NewZone;
            base.Dispose();
        }
    }
}
