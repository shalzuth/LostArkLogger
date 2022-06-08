using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpc_1_4_1
    {
        public PKTNewNpc_1_4_1(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) SteamDecode(reader);
        }
        public UInt16 field0;
        public Int64 field1;
        public UInt64 field2;
        public Byte field3;
        public Int64 field4;
        public Byte field5;
        public Byte field6;
    }
}
