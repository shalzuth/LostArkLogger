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
			if (!CheckFirewall()) return;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
		}
		static Boolean CheckFirewall()
		{
			var ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
			var ipLocalEndPoint = new IPEndPoint(ipAddress, 12345);
			var t = new TcpListener(ipLocalEndPoint);
			t.Start();
			t.Stop();
			var firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
			foreach (INetFwRule firewallRule in firewallPolicy.Rules)
				if (firewallRule.Name != null && firewallRule.ApplicationName?.Equals(Process.GetCurrentProcess().MainModule.FileName, StringComparison.OrdinalIgnoreCase) == true)
					if ((firewallRule.Profiles & (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC) > 0 && firewallRule.Action == NET_FW_ACTION_.NET_FW_ACTION_ALLOW) return true;
			MessageBox.Show("This program needs to be added to Firewall!");
			return false;
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
