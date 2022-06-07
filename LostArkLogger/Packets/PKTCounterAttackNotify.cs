using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTCounterAttackNotify
    {
        public PKTCounterAttackNotify(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public Byte[] field0;
        public UInt64 TargetId;
        public Byte field2;
        public UInt64 SourceId;
    }
}
