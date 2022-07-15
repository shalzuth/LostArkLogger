using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatPair
    {
        public StatPair(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public List<Int64> Value = new List<Int64>();
        public List<Byte> StatType = new List<Byte>();
        public UInt16 num;
    }
}
