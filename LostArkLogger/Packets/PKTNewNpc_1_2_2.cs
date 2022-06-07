using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpc_1_2_2
    {
        public PKTNewNpc_1_2_2(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public UInt32 num;
        public List<Byte> field0s = new List<Byte>();
    }
}
