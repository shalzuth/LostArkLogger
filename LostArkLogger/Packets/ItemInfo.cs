using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class ItemInfo
    {
        public ItemInfo(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public List<Byte[]> field0;
        public Byte hasfield1;
        public Byte field1;
        public UInt32 field2;
        public UInt16 field3;
        public UInt64 field4;
        public UInt16 Level;
    }
}
