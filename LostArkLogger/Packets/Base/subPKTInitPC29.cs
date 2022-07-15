using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTInitPC29
    {
        public subPKTInitPC29(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public Int64 p64_0;
        public Int64 p64_1;
        public UInt64 u64;
        public UInt16 u16;
        public Byte b_0;
        public Byte b_1;
        public Byte b_2;
    }
}
