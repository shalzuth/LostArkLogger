using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageAbnormalMoveNotify
    {
        public PKTSkillDamageAbnormalMoveNotify(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public UInt32 SkillEffectId;
        public UInt32 SkillId;
        public UInt64 SourceId;
        public UInt32 field3;
        public List<SkillDamageMoveEvent> skillDamageMoveEvents;
        public Byte field5;
    }
}
