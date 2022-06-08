using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillRunes
    {
        public SkillRunes(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) SteamDecode(reader);
        }
        public UInt16 num;
        public List<List<UInt32>> field0s = new List<List<UInt32>>();
        public List<UInt32> field1s = new List<UInt32>();
    }
}
