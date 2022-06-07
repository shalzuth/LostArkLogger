using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTRemoveObject
    {
        public PKTRemoveObject(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public UInt64 field0;
        public String field1;
    }
}
