using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatChangeOriginNotify
    {
        public PKTStatChangeOriginNotify(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public Byte hasfield0;
        public UInt32 field0;
        public StatPair StatPairChangedList;
        public Byte field2;
        public StatPair StatPairList;
        public UInt64 ObjectId;
    }
}
