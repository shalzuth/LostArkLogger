using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public static class VersionCheck
    {
        public static Version SupportedSteamVersion = new Version("1.32.55.1800897");
        public static Version GetLostArkVersion()
        {
            var fileName = @"C:\Program Files (x86)\Steam\steamapps\common\Lost Ark\Binaries\Win64\LOSTARK.exe";
            if (!File.Exists(fileName))
            {
                var installLocation = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 1599340")?.GetValue("InstallLocation");
                if (installLocation != null)
                {
                    fileName = Path.Combine(installLocation.ToString(), "Binaries", "Win64", "LOSTARK.exe");
                }
            }
            return new Version(FileVersionInfo.GetVersionInfo(fileName).ProductVersion.Split(' ')[0]);
        }
    }
}
