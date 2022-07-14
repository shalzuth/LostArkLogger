using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using LostArkLogger.Utilities;

namespace LostArkLogger
{
    public class HttpBridge
    {
        private static uint Port = 13345U;

        private readonly HttpClient http = new HttpClient();
        private readonly ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string>();
        private Thread thread;

        public string[] args;

        public void Start()
        {
            EnqueueMessage(0, "Arguments: " + String.Join(",", args));

            // Configure the monitor with command-line arguments.
            var RegionIndex = Array.IndexOf(args, "--Region");
            var NpcapIndex = Array.IndexOf(args, "--UseNpcap");
            var PortIndex = Array.IndexOf(args, "--Port");

            if (PortIndex != -1)
            {
                Port = uint.Parse(args[PortIndex + 1]);
            }

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string loaPath = Path.Combine(documentsPath, "LOA Details");
            string logsPath = Path.Combine(loaPath, "Logs");

            if (!Directory.Exists(loaPath)) Directory.CreateDirectory(loaPath);
            if (!Directory.Exists(logsPath)) Directory.CreateDirectory(logsPath);

            Oodle.Init();

            var sniffer = new Parser();

            //if (RegionIndex != -1)
            //{
            //    if (args[RegionIndex + 1] == "Russia")
            //    {
            //        sniffer.region = Properties.Settings.Default.Region.Russia;
            //        EnqueueMessage("message", "Using Russia client!");
            //    }
            //    else if (args[RegionIndex + 1] == "Korea")
            //    {
            //        sniffer.region = Properties.Settings.Default.Region.Korea;
            //        EnqueueMessage("message", "Using Korea client!");
            //    }
            //}

            if (NpcapIndex != -1)
            {
                sniffer.use_npcap = true;
                sniffer.InstallListener();
                if (!sniffer.use_npcap)
                {
                    EnqueueMessage(0, "Failed to initialize Npcap, using raw sockets instead. You can try to restart the app.");
                }
                else
                {
                    EnqueueMessage(0, "Using Npcap!");
                }

            }

            Logger.onLogAppend += (string log) =>
            {
                EnqueueMessage(log);
            };

            EnqueueMessage(0, "All connections are ready");

            this.thread = new Thread(this.Run);
            this.thread.Start();

            Console.ReadLine();
        }

        private void EnqueueMessage(string log)
        {
            this.messageQueue.Enqueue(log);
        }
        private void EnqueueMessage(int id, params string[] elements)
        {
            var log = id + "|" + DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'") + "|" + String.Join("|", elements);
            this.messageQueue.Enqueue(log);
        }

        private async void Run()
        {
            while (true)
            {
                if (this.messageQueue.TryDequeue(out var sendMessage))
                {
#if DEBUG
                    Console.WriteLine("Sending: " + sendMessage);
#endif
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:" + Port);
                    request.Content = new StringContent(sendMessage);
                    var mediaTypeHeaderValue = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                    mediaTypeHeaderValue.CharSet = "utf-8";
                    request.Content.Headers.ContentType = mediaTypeHeaderValue;

                    await this.http.SendAsync(request);
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
        }
    }
}
