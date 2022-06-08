using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitEnv
    {
        public PKTInitEnv(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) SteamDecode(reader);
        }
        public PKTInitEnv_1 pKTInitEnv_1;
        public Byte field1;
        public UInt64 PlayerId;
        public UInt64 field3;
        public UInt64 field4;
        public UInt32 field5;
        public UInt32 field6;
        public List<Byte> field7;
    }
}
