using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillStageNotify
    {
        public PKTSkillStageNotify(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public UInt64 SourceId;
        public Byte[] field1;
        public UInt32 SkillId;
        public Byte[] field3;
        public Byte Stage;
    }
}
