using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillRunes
    {
        public SkillRunes(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public List<List<UInt32>> u32list = new List<List<UInt32>>();
        public List<UInt32> u32 = new List<UInt32>();
        public UInt16 num;
    }
}
