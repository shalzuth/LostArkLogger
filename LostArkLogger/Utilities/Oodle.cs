using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LostArkLogger
{
    internal class Oodle
    {
        [DllImport("kernel32")] static extern bool SetDllDirectory(string lpPathName);
        [DllImport("oo2net_9_win64")] static extern bool OodleNetwork1UDP_Decode(byte[] state, byte[] shared, byte[] comp, int compLen, byte[] raw, int rawLen);
        [DllImport("oo2net_9_win64")] static extern bool OodleNetwork1UDP_State_Uncompact(byte[] state, byte[] compressorState);
        [DllImport("oo2net_9_win64")] static extern void OodleNetwork1_Shared_SetWindow(byte[] data, int length, byte[] data2, int length2);
        [DllImport("oo2net_9_win64")] static extern int OodleNetwork1UDP_State_Size();
        [DllImport("oo2net_9_win64")] static extern int OodleNetwork1_Shared_Size(int bits);
        static Byte[] oodleState;
        static Byte[] oodleSharedDict;
        static Byte[] initDict;
        const string oodleDll = "oo2net_9_win64.dll";
        public static void Init()
        {
            var lostArkProcesses = Process.GetProcessesByName("LOSTARK");
            foreach (var lostArkProcess in lostArkProcesses)
            {
                var sb = new StringBuilder(1024);
                int bufferLength = sb.Capacity + 1;
                VersionCheck.QueryFullProcessImageName(lostArkProcess.Handle, 0, sb, ref bufferLength);
                var lostArkExe = sb.ToString();
                var lostArkPath = Path.GetDirectoryName(lostArkExe);
                SetDllDirectory(lostArkPath);
            }
            var payload = ObjectSerialize.Decompress(Properties.Settings.Default.Region == Region.Steam ? Properties.Resources.oodle_state_Steam : Properties.Resources.oodle_state_Korea); // to do select correct bin
            initDict = payload.Skip(0x20).Take(0x800000).ToArray();
            var compressorSize = BitConverter.ToInt32(payload, 0x18);
            var compressorState = payload.Skip(0x20).Skip(0x800000).Take(compressorSize).ToArray();
            var stateSize = OodleNetwork1UDP_State_Size();
            oodleState = new Byte[stateSize];
            if (!OodleNetwork1UDP_State_Uncompact(oodleState, compressorState)) throw new Exception("oodle init fail");
            oodleSharedDict = new Byte[OodleNetwork1_Shared_Size(0x13)];
            OodleNetwork1_Shared_SetWindow(oodleSharedDict, 0x13, initDict, 0x800000);
        }
        public static Byte[] Decompress(Byte[] decompressed)
        {
            var oodleSize = BitConverter.ToInt32(decompressed, 0);
            var payload = decompressed.Skip(4).ToArray();
            var tempPayload = new Byte[oodleSize];
            try
            {
                if (!OodleNetwork1UDP_Decode(oodleState, oodleSharedDict, payload, payload.Length, tempPayload, oodleSize))
                    throw new Exception("oodle decompress fail");
            }
            catch //(Exception e)
            {
                //Console.WriteLine("access excepted");
            }
            return tempPayload;
        }
    }
}
