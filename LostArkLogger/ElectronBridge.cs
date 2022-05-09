using ElectronCgi.DotNet;
using System.IO;

namespace LostArkLogger
{
    public class ElectronBridge
    {
        public string[] args;

        public void Run()
        {
            bool useWinpcap = false;

            var ElectronConnection = new ConnectionBuilder().UsingEncoding(System.Text.Encoding.UTF8).Build();

            foreach (var arg in args)
            {
                if (arg == "useWinpcap") useWinpcap = true;
            }

            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
            Oodle.Init();

            var sniffer = new Parser();
            if (useWinpcap)
            {
                ElectronConnection.Send("message", "Using winpcap");
                sniffer.use_npcap = useWinpcap;
                sniffer.InstallListener();
            }

            sniffer.onCombatEvent += (LogInfo logInfo) =>
            {
                ElectronConnection.Send("combat-event", logInfo.ElectronFormattedString());
            };

            sniffer.onNewZone += () =>
            {
                ElectronConnection.Send("new-zone", "1");
            };

            ElectronConnection.Send("message", "All connections are ready.");
            ElectronConnection.Listen();
        }
    }
}
