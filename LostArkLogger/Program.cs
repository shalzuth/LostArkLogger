using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;

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
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
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
				catch (Exception ex) { MessageBox.Show("This program must be run as an administrator! \n\n" + ex.ToString()); }
				return false;
			}
			return true;
		}
	}
}
