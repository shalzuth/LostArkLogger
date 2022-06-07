using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatPair
    {
        public StatPair(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public UInt16 num;
        public List<Int64> Value = new List<Int64>();
        public List<Byte> StatType = new List<Byte>();
    }
}
