using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using NetFwTypeLib;

namespace LostArkLogger
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			if (!AdminRelauncher()) return;
			AttemptFirewallPrompt();
			Application.EnableVisualStyles();
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
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
					FileName = Environment.ProcessPath,
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
