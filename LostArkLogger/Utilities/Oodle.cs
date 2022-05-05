using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LostArkLogger
{
    internal class Oodle
    {
        [DllImport("oo2net_9_win64")] static extern bool OodleNetwork1UDP_Decode(byte[] state, byte[] shared, byte[] comp, int compLen, byte[] raw, int rawLen);
        [DllImport("oo2net_9_win64")] static extern bool OodleNetwork1UDP_State_Uncompact(byte[] state, byte[] compressorState);
        [DllImport("oo2net_9_win64")] static extern void OodleNetwork1_Shared_SetWindow(byte[] data, int length, byte[] data2, int length2);
        [DllImport("oo2net_9_win64")] static extern int OodleNetwork1UDP_State_Size();
        [DllImport("oo2net_9_win64")] static extern int OodleNetwork1_Shared_Size(int bits);
        static Byte[] oodleState;
        static Byte[] oodleSharedDict;
        public static void Init()
        {
            while (!File.Exists("oo2net_9_win64.dll"))
            {
                if (File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Lost Ark\Binaries\Win64\oo2net_9_win64.dll"))
                {
                    File.Copy(@"C:\Program Files (x86)\Steam\steamapps\common\Lost Ark\Binaries\Win64\oo2net_9_win64.dll", "oo2net_9_win64.dll");
                    continue;
                }
                var steamPath = Path.Combine(Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam").GetValue("SteamPath").ToString(), "steamapps");
                var oodleDll = steamPath + @"\common\Lost Ark\Binaries\Win64\oo2net_9_win64.dll";
                if (File.Exists(oodleDll))
                {
                    File.Copy(oodleDll, "oo2net_9_win64.dll");
                    continue;
                }
                if (MessageBox.Show("please copy oo2net_9_win64 from LostArk\\Binaries\\Win64 directory to current directory", "Missing DLL") != DialogResult.OK) return;
            }
            var payload = ObjectSerialize.Decompress(Properties.Resources.oodle_state);
            var dict = payload.Skip(0x20).Take(0x800000).ToArray();
            var compressorSize = BitConverter.ToInt32(payload, 0x18);
            var compressorState = payload.Skip(0x20).Skip(0x800000).Take(compressorSize).ToArray();
            var stateSize = OodleNetwork1UDP_State_Size();
            oodleState = new Byte[stateSize];
            if (!OodleNetwork1UDP_State_Uncompact(oodleState, compressorState)) throw new Exception("oodle init fail");
            oodleSharedDict = new Byte[OodleNetwork1_Shared_Size(0x13) * 2];
            OodleNetwork1_Shared_SetWindow(oodleSharedDict, 0x13, dict, 0x800000);
        }
        public static Byte[] Decompress(Byte[] decompressed)
        {
            var oodleSize = BitConverter.ToInt32(decompressed, 0);
            var payload = decompressed.Skip(4).ToArray();
            var tempPayload = new Byte[oodleSize];
            try
            {
                if (!OodleNetwork1UDP_Decode(oodleState, oodleSharedDict, payload, payload.Length, tempPayload, oodleSize))
                {
                    Init();
                    if (!OodleNetwork1UDP_Decode(oodleState, oodleSharedDict, payload, payload.Length, tempPayload, oodleSize))
                        throw new Exception("oodle decompress fail");
                }
            }
            catch
            {
                Init();
                return Decompress(decompressed);
            }
            return tempPayload;
        }
    }
}
