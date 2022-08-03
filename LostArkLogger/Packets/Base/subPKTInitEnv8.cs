using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTInitEnv8
    {
        public subPKTInitEnv8(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public List<List<UInt16>> u16list_0 = new List<List<UInt16>>();
        public List<List<UInt16>> u16list_1 = new List<List<UInt16>>();
        public List<List<UInt16>> u16list_2 = new List<List<UInt16>>();
        public UInt16 num;
    }
}
