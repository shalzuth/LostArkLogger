using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTInitEnv5
    {
        public subPKTInitEnv5(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public List<List<Byte>> blist_0 = new List<List<Byte>>();
        public List<List<Byte>> blist_1 = new List<List<Byte>>();
        public List<List<Byte>> blist_2 = new List<List<Byte>>();
        public UInt16 num;
    }
}
