using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
namespace LostArkLogger
{
    internal static class Program
    {
        public static bool IsConsole = Console.OpenStandardInput(1) != Stream.Null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (!AdminRelauncher()) return;
            AttemptFirewallPrompt();

            if (!IsConsole)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());
            }
            else
            {
                var httpBridge = new HttpBridge();
                httpBridge.args = args;
                httpBridge.Start();
            }
        }
        static void AttemptFirewallPrompt()
        {
            var ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            var ipLocalEndPoint = new IPEndPoint(ipAddress, 12345);
            var t = new TcpListener(ipLocalEndPoint);
            t.Start();
            t.Stop();
        }

        private static bool AdminRelauncher()
        {
            if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                var startInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                    FileName = Assembly.GetEntryAssembly().CodeBase,
                    Verb = "runas"
                };
                try { Process.Start(startInfo); }
                catch (Exception ex) { MessageBox.Show("This program must be run as an administrator!\n" + ex.ToString()); }
                return false;
            }
            return true;
        }
    }
}
