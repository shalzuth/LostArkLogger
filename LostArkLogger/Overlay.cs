﻿using System;
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
        enum Level // need better state, suboverlay type/etc.
        {
            None,
            Damage,
            Counterattacks,
            Stagger,
            Heal,
            Shield,
            Death,
            Max
        }
        enum Scope // need better state, suboverlay type/etc.
        {
            TopLevel,
            Encounters,
            Player
        }
        Level level = Level.Damage;
        Scope scope = Scope.TopLevel;
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
            encounter = sniffer.currentEncounter;
        }
        Encounter encounter;
        Entity SubEntity;
        Font font = new Font("Helvetica", 10);
        void AddDamageEvent(LogInfo log)
        {
            if (sniffer.currentEncounter.Infos.Count > 0) encounter = sniffer.currentEncounter;
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
        public Pen arrowPen = new Pen(Color.FromArgb(255, 255, 255, 255), 4) { StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor };
        IOrderedEnumerable<KeyValuePair<String, Tuple<UInt64, UInt32, UInt32>>> orderedRows;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            e.Graphics.FillRectangle(brushes[10], 0, 0, Size.Width, barHeight);

            var title = "DPS Meter";
            if (scope == Scope.Encounters) title = "Encounters";
            else
            {
                title = level.ToString();
                if (scope == Scope.Player) title += " (" + SubEntity.VisibleName + ")";
            }
            var titleBar = e.Graphics.MeasureString(title, font);
            var heightBuffer = (barHeight - titleBar.Height) / 2;
            e.Graphics.DrawString(title, font, black, 5, heightBuffer);

            if (scope == Scope.Encounters)
            {
                for (var i = 0; i < sniffer.Encounters.Count; i++)
                {
                    e.Graphics.FillRectangle(brushes[i % brushes.Count], 0, (i + 1) * barHeight, Size.Width, barHeight);
                    e.Graphics.DrawString(sniffer.Encounters.ElementAt(sniffer.Encounters.Count - i - 1).EncounterName, font, black, 5, (i + 1) * barHeight + heightBuffer);
                }
            }
            else
            {
                var rows = encounter.GetDamages((i => (Single)(
                    level == Level.Damage ? i.Damage : 
                    level == Level.Stagger ? i.Stagger :
                    level == Level.Counterattacks ? (i.Counter ? 1u : 0) :
                    level == Level.Heal ? i.Heal :
                    level == Level.Shield ? i.Shield : 
                    level == Level.Death ? (i.Death ? 1u : 0) : 0)), SubEntity);
                if (level == Level.Damage) rows = encounter.GetDamages((i => i.Damage), SubEntity);
                else if (level == Level.Counterattacks) rows = encounter.Counterattacks.ToDictionary(x => x.Key, x => Tuple.Create(x.Value, 0u, 0u));
                else if (level == Level.Death) rows = encounter.Deaths.ToDictionary(x => x.Key, x => Tuple.Create(x.Value,0u, 0u));
                else if (level == Level.Stagger) rows = encounter.Stagger.ToDictionary(x => x.Key, x => Tuple.Create(x.Value, 0u, 0u));
                var elapsed = ((encounter.End == default(DateTime) ? DateTime.Now : encounter.End) - encounter.Start).TotalSeconds;
                var maxDamage = rows.Count == 0 ? 0 : rows.Max(b => b.Value.Item1);
                var totalDamage = rows.Values.Sum(b => (Single)b.Item1);
                orderedRows = rows.OrderByDescending(b => b.Value);
                for (var i = 0; i < orderedRows.Count(); i++)
                {
                    var playerDmg = orderedRows.ElementAt(i);
                    var rowText = playerDmg.Key;
                    var barWidth = ((Single)playerDmg.Value.Item1 / maxDamage) * Size.Width;
                    //if (barWidth < .3f) continue;
                    e.Graphics.FillRectangle(brushes[i % brushes.Count], 0, (i + 1) * barHeight, barWidth, barHeight);
                    var dps = FormatNumber((ulong)(playerDmg.Value.Item1 / elapsed));
                    var formattedDmg = FormatNumber(playerDmg.Value.Item1) + " (" + dps + ", " + (1f * playerDmg.Value.Item1 / totalDamage).ToString("P1");
                    if (level == Level.Damage && Width > 450)
                    {
                        formattedDmg += " | H: " + playerDmg.Value.Item2 + " | C: " + (1f * playerDmg.Value.Item3 / playerDmg.Value.Item2).ToString("P1");
                    }
                    var nameOffset = 0;
                    if (rowText.Contains("(") && scope == Scope.TopLevel)
                    {
                        var className = rowText.Substring(rowText.IndexOf("(") + 1);
                        className = className.Substring(0, className.IndexOf(")")).Split(' ')[1];
                        e.Graphics.DrawImage(Properties.Resources.class_symbol_0, new Rectangle(2, (i + 1) * barHeight + 2, barHeight - 4, barHeight - 4), GetSpriteLocation(Array.IndexOf(ClassIconIndex, className)), GraphicsUnit.Pixel);
                        nameOffset += 16;
                    }
                    if (scope == Scope.Player)
                    {
                        /*if (Skill.GetSkillIcon(uint.Parse(rowText), out String iconFile, out int iconIndex))
                        {
                            nameOffset += 16;
                            e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject(iconFile.ToLower()), new Rectangle(2, (i + 1) * barHeight + 2, barHeight - 4, barHeight - 4), GetSpriteLocation(iconIndex), GraphicsUnit.Pixel);
                        }*/
                        var skillid = rowText.Substring(1);
                        skillid = skillid.Substring(0, skillid.IndexOf(")"));
                        rowText = Skill.GetSkillName(uint.Parse(skillid));
                    }
                    var edge = e.Graphics.MeasureString(formattedDmg, font);
                    e.Graphics.DrawString(rowText, font, black, nameOffset + 5, (i + 1) * barHeight + heightBuffer);
                    e.Graphics.DrawString(formattedDmg, font, black, Size.Width - edge.Width, (i + 1) * barHeight + heightBuffer);
                }
            }
            ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(Size.Width - 50, barHeight / 4, 10, barHeight / 2));
            e.Graphics.DrawLine(arrowPen, Size.Width - 30, barHeight / 2, Size.Width - 20, barHeight / 2);
            e.Graphics.DrawLine(arrowPen, Size.Width - 5, barHeight / 2, Size.Width - 15, barHeight / 2);
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
                    if (scope == Scope.TopLevel)
                    {
                        var entityName = orderedRows.ElementAt(index).Key;
                        SubEntity = encounter.Infos.First(i => i.SourceEntity.VisibleName == entityName).SourceEntity;
                        SwitchOverlay(Scope.Player);
                    }
                    if (scope == Scope.Encounters)
                    {
                        encounter = sniffer.Encounters.ElementAt(sniffer.Encounters.Count - index - 1);
                        SwitchOverlay(Scope.TopLevel);
                    }
                }
                if (new Rectangle(Size.Width - 50, barHeight / 4, 10, barHeight / 2).Contains(e.Location)) SwitchOverlay(Scope.Encounters);
                if (new Rectangle(Size.Width - 30, 0, 10, barHeight).Contains(e.Location)) SwitchOverlay(false);
                if (new Rectangle(Size.Width - 15, 0, 10, barHeight).Contains(e.Location)) SwitchOverlay(true);
            }
            if (e.Button == MouseButtons.Right)
            {
                if (scope == Scope.Player)
                    SwitchOverlay(Scope.TopLevel);
                else if (scope == Scope.TopLevel)
                    SwitchOverlay(Scope.Encounters);
            }
        }
        void SwitchOverlay(bool progress) 
        {
            if (progress) level++;
            else level--;
            if (level == Level.None) level = Level.Max - 1;
            else if (level == Level.Max) level = Level.None + 1;
            Invalidate();
        }
        void SwitchOverlay(Level type)
        {
            level = type;
            Invalidate();
        }
        void SwitchOverlay(Scope type)
        {
            if (type != Scope.Player) SubEntity = null;
            scope = type;
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
            base.Dispose();
        }
    }
}
