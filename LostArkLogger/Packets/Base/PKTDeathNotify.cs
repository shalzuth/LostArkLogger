using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTDeathNotify
    {
        public PKTDeathNotify(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public UInt64 SourceId;
        public UInt64 TargetId;
        public UInt64 u64_0;
        public UInt32 u32_0;
        public UInt16 u16_0;
        public Byte b_0;
        public Byte b_1;
        public Byte b_2;
        public Byte b_3;
        public Byte b_4;
        public Byte b_5;
        public Byte b_6;
    }
}
