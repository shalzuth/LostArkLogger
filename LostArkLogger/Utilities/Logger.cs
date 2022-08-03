using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger.Utilities
{
    public static class Logger
    {
        static string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static string logsPath = Path.Combine(documentsPath, "Lost Ark Logs");

        public static bool debugLog = false;

        static BinaryWriter logger;
        static FileStream logStream;

        private static readonly object LogFileLock = new object();
        private static readonly object DebugFileLock = new object();
        public static string fileName = logsPath + "\\LostArk_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";

        static Logger()
        {
            if (!Directory.Exists(logsPath)) Directory.CreateDirectory(logsPath);
        }
        public static void StartNewLogFile()
        {
            fileName = logsPath + "\\LostArk_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".log";
        }
        public static event Action<string> onLogAppend;
        static bool InittedLog = false;
        public static void AppendLog(int id, params string[] elements)
        {
            if (InittedLog == false)
            {
                InittedLog = true;
                AppendLog(253, System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString());
            }
            var log = id + "|" + DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'") + "|" + String.Join("|", elements);
            var logHash = string.Concat(System.Security.Cryptography.MD5.Create().ComputeHash(Encoding.Unicode.GetBytes(log)).Select(x => x.ToString("x2")));

            Task.Run(() =>
            {
                lock (LogFileLock)
                {
                    File.AppendAllText(fileName, log + "|" + logHash + "\n");
                }

                onLogAppend?.Invoke(log + "\n");
            });
        }
        public static void DoDebugLog(byte[] bytes)
        {
            if (debugLog)
            {
                Task.Run(() =>
                {
                    var log = BitConverter.GetBytes(DateTime.Now.ToBinary())
                        .Concat(BitConverter.GetBytes(bytes.Length)).Concat(bytes).ToArray();

                    lock (DebugFileLock)
                    {
                        if (logger == null)
                        {
                            logStream = new FileStream(fileName.Replace(".log", ".bin"), FileMode.Create);
                            logger = new BinaryWriter(logStream);
                        }

                        logger.Write(log);
                    }
                });
            }
        }
    }
}
