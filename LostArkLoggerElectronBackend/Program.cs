using ElectronCgi.DotNet;
using LostArkLogger;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Net;
using System.Net.Sockets;
using System;
using System.IO;

class Program
{
	#if DEBUG
		public static bool debugMode = true;
	#else
		public static bool debugMode = false;
	#endif

	static void Main(string[] args)
	{
		if (!AdminRelauncher()) System.Environment.Exit(1);
		AttemptFirewallPrompt();


		var ElectronConnection = new ConnectionBuilder()
							.Build();

		if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");

		if (Oodle.Init() == OodleInitStatus.OODLE_DLL_FAIL)
        {
			Console.WriteLine("Please copy oo2net_9_win64 from LostArk\\Binaries\\Win64 directory to current directory", "Missing DLL");
			System.Environment.Exit(1);
			return;
		}

		var sniffer = new Parser();
		
		sniffer.onCombatEvent += (LogInfo logInfo) =>
		{
			if (debugMode)
            {
				Console.WriteLine("Combat Event: " + logInfo.ToString());
			}
			ElectronConnection.Send("combatEvent", logInfo.ToString());
		}; 
		sniffer.onNewZone += () =>
		{
			if (debugMode)
			{
				Console.WriteLine("New zone");
			}
			ElectronConnection.Send("newZone", "newZone");
		};
		

		// Wait for incoming requests from Electron
		ElectronConnection.Send("log", "Initialized packet sniffer");
		ElectronConnection.Listen();
	}

	static void AttemptFirewallPrompt()
	{
		var ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
		var ipLocalEndPoint = new IPEndPoint(ipAddress, 12345);
		var t = new TcpListener(ipLocalEndPoint);
		t.Start();
		t.Stop();
	}

	static bool AdminRelauncher()
	{
		#pragma warning disable CA1416 // Validate platform compatibility
        if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
		{
			var assembly = Assembly.GetEntryAssembly();
			if (assembly == null || assembly.Location == null)
            {
				Console.WriteLine("Unable to relaunch as admin. GetEntryAssembly() or assembly.Location is null");
				return false;
            }

			var startInfo = new ProcessStartInfo
			{
				UseShellExecute = true,
				WorkingDirectory = Environment.CurrentDirectory,
				FileName = assembly.Location,
				Verb = "runas"
			};
			try { Process.Start(startInfo); }
			catch (Exception ex) { 
				Console.WriteLine("This program must be run as an administrator!\n" + ex.ToString());
				return false;
			}
		}
        return true;
	}


}