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
            bool useKoreaClient = false;
            bool useRussiaClient = false;

            var ElectronConnection = new ConnectionBuilder().UsingEncoding(System.Text.Encoding.UTF8).Build();

            foreach (var arg in args)
            {
                if (arg == "useWinpcap") useWinpcap = true;
                if (arg == "koreaClient") useKoreaClient = true;
                if (arg == "russiaClient") useRussiaClient = true;
            }

            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string loaPath = Path.Combine(documentsPath, "LOA Details");
            string logsPath = Path.Combine(loaPath, "Logs");

            if (!Directory.Exists(loaPath)) Directory.CreateDirectory(loaPath);
            if (!Directory.Exists(logsPath)) Directory.CreateDirectory(logsPath);

            Oodle.Init();

            var sniffer = new Parser();

            if (useKoreaClient)
            {
                sniffer.region = Parser.Region.Korea;
                ElectronConnection.Send("message", "Using Korean client!");
            }

            if (useRussiaClient)
            {
                sniffer.region = Parser.Region.Russia;
                ElectronConnection.Send("message", "Using Russian client!");
            }

            if (useWinpcap)
            {
                sniffer.use_npcap = useWinpcap;
                sniffer.InstallListener();
                if (useWinpcap && !sniffer.use_npcap)
                {
                    ElectronConnection.Send("message", "Failed to initialize winpcap, using raw sockets instead. You can try to restart the app.");
                }
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
