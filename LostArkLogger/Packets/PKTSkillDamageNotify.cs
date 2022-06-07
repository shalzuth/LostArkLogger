using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageNotify
    {
        public PKTSkillDamageNotify(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public Byte field0;
        public UInt32 SkillId;
        public UInt64 SourceId;
        public UInt32 SkillEffectId;
        public List<SkillDamageEvent> skillDamageEvents;
    }
}
