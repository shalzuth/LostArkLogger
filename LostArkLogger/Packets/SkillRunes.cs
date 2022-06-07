using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillRunes
    {
        public SkillRunes(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public UInt16 num;
        public List<List<UInt32>> field0s = new List<List<UInt32>>();
        public List<UInt32> field1s = new List<UInt32>();
    }
}
