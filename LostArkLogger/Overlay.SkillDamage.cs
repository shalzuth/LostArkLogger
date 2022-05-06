using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LostArkLogger
{
    public partial class Overlay_SkillDamage : Form
    {
        public Overlay_SkillDamage()
        {
            InitPens();
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
        }
        public ConcurrentDictionary<String, UInt64> Damages = new ConcurrentDictionary<string, ulong>();
        public string owner = "";

        Font font = new Font("Helvetica", 10);
        List<Brush> brushes = new List<Brush>();
        Brush black = new SolidBrush(Color.White);
        void InitPens()
        {
            String[] colors = {"#3366cc", "#dc3912", "#ff9900", "#109618", "#990099", "#0099c6", "#dd4477", "#66aa00", "#b82e2e", "#316395", "#994499", "#22aa99", "#aaaa11", "#6633cc", "#e67300", "#8b0707", "#651067", "#329262", "#5574a6", "#3b3eac", "#b77322", "#16d620", "#b91383", "#f4359e", "#9c5935", "#a9c413", "#2a778d", "#668d1c", "#bea413", "#0c5922", "#743411" };
            foreach(var color in colors) brushes.Add(new SolidBrush(ColorTranslator.FromHtml(color)));
        }

        public void Update(ConcurrentDictionary<String, UInt64> SkillDmg) {
            Damages = SkillDmg;
            Invalidate();
        }

        public void Clear() {
            Damages.Clear();
            Invalidate();
        }

        int barHeight = 20;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            e.Graphics.FillRectangle(brushes[15], 0, 0, Size.Width, barHeight);
            var titleBar = e.Graphics.MeasureString("Details(" + owner + ")", font);
            e.Graphics.DrawString("X", font, black, Size.Width - 15, 0);
            var heightBuffer = (barHeight - titleBar.Height) / 2;
            e.Graphics.DrawString("DPS Meter", font, black, 5, heightBuffer);
            if(Damages.Count == 0) return;
            var maxDamage = Damages.Max(b => b.Value);
            var totalDamage = Damages.Values.Sum(b => (Single)b);
            var orderedDamages = Damages.OrderByDescending(b => b.Value);
            for(var i = 0; i < Damages.Count && i < 8; i++) {
                var playerDmg = orderedDamages.ElementAt(i);
                var barWidth = ((Single)playerDmg.Value / maxDamage) * Size.Width;
                if(barWidth < .3f) continue;
                e.Graphics.FillRectangle(brushes[i], 0, (i + 1) * barHeight, barWidth, barHeight);
                var formattedDmg = Overlay.FormatNumber(playerDmg.Value) + " (" + (100f * playerDmg.Value / totalDamage).ToString("#.0") + "%)";
                var nameOffset = 0;
                var edge = e.Graphics.MeasureString(formattedDmg, font);
                e.Graphics.DrawString(playerDmg.Key, font, black, nameOffset + 5, (i + 1) * barHeight + heightBuffer);
                e.Graphics.DrawString(formattedDmg, font, black, Size.Width - edge.Width, (i + 1) * barHeight + heightBuffer);
            }
            ControlPaint.DrawSizeGrip(e.Graphics, BackColor, ClientSize.Width - 16, ClientSize.Height - 16, 16, 16);
        }

        [DllImport("user32.dll")] static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")] static extern bool ReleaseCapture();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private void Overlay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                if((e.Location.X >= Size.Width - 15 && e.Location.X <= Size.Width - 5) && e.Location.Y <= 15)
                    this.Visible = false;
            }
        }

        protected override void WndProc(ref Message m) {
            const int wmNcHitTest = 0x84;
            const int htBottomLeft = 16;
            const int htBottomRight = 17;
            if(m.Msg == wmNcHitTest) {
                var x = (int)(m.LParam.ToInt64() & 0xFFFF);
                var y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);
                var pt = PointToClient(new Point(x, y));
                var clientSize = ClientSize;
                if(pt.X >= clientSize.Width - 16 && pt.Y >= clientSize.Height - 16 && clientSize.Height >= 16) {
                    m.Result = (IntPtr)(IsMirrored ? htBottomLeft : htBottomRight);
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
}

