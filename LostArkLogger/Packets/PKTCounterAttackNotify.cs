using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTCounterAttackNotify
    {
        public PKTCounterAttackNotify(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) SteamDecode(reader);
        }
        public Byte[] field0;
        public Byte[] field2;
        public Byte[] field4;
        public UInt64 SourceId;
        public UInt64 TargetId;
    }
}
