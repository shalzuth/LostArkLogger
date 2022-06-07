using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpc_1_2
    {
        public PKTNewNpc_1_2(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public Byte field0;
        public UInt16 field1;
        public String field2;
        public Byte field3;
        public UInt64 field4;
        public Byte field5;
        public List<ItemInfo> itemInfos;
        public PKTNewNpc_1_2_2 pKTNewNpc_1_2_2;
    }
}
