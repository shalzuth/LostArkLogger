using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
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
			// this will only create an "allow this app through the firewall" dialog one time, and only if prompting is enabled.
			var ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
			var ipLocalEndPoint = new IPEndPoint(ipAddress, 12345);
			var t = new TcpListener(ipLocalEndPoint);
			t.Start();
			t.Stop();

			var attempts = 0;

			while (attempts < 2)
			{
				var firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
				// is the firewall disabled for all active profiles?
				Func<NET_FW_PROFILE_TYPE2_, INetFwPolicy2, bool> isEnabled = (type, policy) => { return (((int)type & policy.CurrentProfileTypes) != 0) && policy.FirewallEnabled[type]; };
				if (!isEnabled(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC, firewallPolicy) &&
					!isEnabled(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE, firewallPolicy) &&
					!isEnabled(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_DOMAIN, firewallPolicy) &&
					!isEnabled(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_ALL, firewallPolicy)
					)
					return true;
				// does our rule exist? we can't accept only public as that does not imply private, and we don't know what profile your NIC is using
				foreach (INetFwRule firewallRule in firewallPolicy.Rules)
					if (firewallRule.Name != null && firewallRule.ApplicationName?.Equals(Process.GetCurrentProcess().MainModule.FileName, StringComparison.OrdinalIgnoreCase) == true)
						if (firewallRule.Action == NET_FW_ACTION_.NET_FW_ACTION_ALLOW && (
								(firewallRule.Profiles & (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC) > 0 &&
								(firewallRule.Profiles & (int)NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE) > 0
							))
							return true;
				// ask the user to allow us
				if (attempts == 0)
				{
					Process proc = new Process();
					proc.StartInfo.FileName = Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe");
					proc.StartInfo.Arguments = @"shell:::{4026492F-2F69-46B8-B9BF-5654FC07E423}\pageConfigureApps";
					proc.StartInfo.UseShellExecute = false;
					proc.Start();
					MessageBox.Show("LostArkLogger is blocked by your firewall - we have opened the control panel where you may:\n1. 'Allow Another App...'\n2. 'Browse...' to LostArkLogger.exe\n3. 'Network Types...' and check both public/private.\n\nWe'll check again when you hit OK!");
				}
				else
				{
					MessageBox.Show("LostArkLogger is still blocked by your firewall! exiting - check #support pins on discord");
					break;
				}
				attempts++;
			}
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
