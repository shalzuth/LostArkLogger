using ElectronCgi.DotNet;
using System.IO;

namespace LostArkLogger
{
    public class ElectronBridge
    {
        public void Run()
        {
            var ElectronConnection = new ConnectionBuilder().Build();

            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
            Oodle.Init();

            var sniffer = new Parser();
            sniffer.onCombatEvent += (LogInfo logInfo) =>
            {
                ElectronConnection.Send("combat-event", logInfo.ToString());
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
