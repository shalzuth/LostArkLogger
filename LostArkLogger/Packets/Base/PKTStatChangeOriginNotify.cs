using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatChangeOriginNotify
    {
        public PKTStatChangeOriginNotify(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public StatPair StatPairChangedList;
        public StatPair StatPairList;
        public UInt64 ObjectId;
        public UInt32 u32_0;
        public Byte b_0;
        public Byte b_1;
    }
}
