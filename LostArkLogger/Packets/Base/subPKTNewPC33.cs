using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewPC33
    {
        public subPKTNewPC33(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public Byte[] bytearray_0;
        public Byte[] bytearray_1;
        public UInt32 u32_0;
        public UInt32 u32_1;
        public Byte b_0;
    }
}
