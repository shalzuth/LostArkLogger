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
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private DateTime startCombatTime = DateTime.Now;

        [DllImport("user32.dll")] static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")] static extern bool ReleaseCapture();
        public Overlay()
        {
            InitPens();
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        internal void AddSniffer(Parser s)
        {
            sniffer = s;
            sniffer.addDamageEvent = AddDamageEvent;
            sniffer.newZone = NewZone;
        }
        public void NewZone()
        {
            Events = new ConcurrentBag<LogInfo>();
            Damages.Clear();
            Invalidate();
        }
        ConcurrentBag<LogInfo> Events = new ConcurrentBag<LogInfo>();
        public ConcurrentDictionary<String, UInt64> Damages = new ConcurrentDictionary<string, ulong>();
        Font font = new Font("Helvetica", 10);
        void AddDamageEvent(LogInfo log)
        {
            if(Damages.Count == 0) startCombatTime = DateTime.Now;
            Events.Add(log);
            if (!Damages.ContainsKey(log.Source)) Damages[log.Source] = 0;
            Damages[log.Source] += log.Damage;
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
        int maxWidth = Screen.PrimaryScreen.Bounds.Width / 6;
        string FormatNumber(UInt64 n) // https://stackoverflow.com/questions/30180672/string-format-numbers-to-millions-thousands-with-rounding
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
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            e.Graphics.FillRectangle(brushes[10], 0, 0, maxWidth, 20);
            e.Graphics.DrawString("DPS Meter", font, black, 5, 0);
            if (Damages.Count == 0) return;
            var maxDamage = Damages.Max(b => b.Value);
            var totalDamage = Damages.Values.Sum(b=>(Single)b);
            var orderedDamages = Damages.OrderByDescending(b => b.Value);
            for (var i = 0; i < Damages.Count && i < 8; i++)
            {
                var elapsed = (DateTime.Now - startCombatTime).TotalSeconds;
                var playerDmg = orderedDamages.ElementAt(i);
                var barWidth = ((Single)playerDmg.Value / maxDamage) * maxWidth;
                if (barWidth < 0.1f) continue;
                e.Graphics.FillRectangle(brushes[i], 0, (i + 1) * 20, barWidth, 20);
                var dps = FormatNumber((ulong)(playerDmg.Value / elapsed));
                var formattedDmg = FormatNumber(playerDmg.Value) + " (" + dps + ", " + (100f * playerDmg.Value / totalDamage).ToString("#.0") + "%)";
                e.Graphics.DrawString(playerDmg.Key, font, black, 5, (i + 1) * 20);
                var edge = e.Graphics.MeasureString(formattedDmg, font);
                e.Graphics.DrawString(formattedDmg, font, black, maxWidth - edge.Width, (i + 1) * 20);
            }
        }

        private void Overlay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
