using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewPC_1
    {
        public PKTNewPC_1(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public UInt32 field0;
        public Byte[] field1;
        public UInt32 field2;
        public Byte hasfield3;
        public Byte[] field3;
    }
}
