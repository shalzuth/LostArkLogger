using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageAbnormalMoveNotify
    {
        public PKTSkillDamageAbnormalMoveNotify(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) SteamDecode(reader);
        }
        public UInt32 SkillEffectId;
        public UInt32 SkillId;
        public UInt64 SourceId;
        public UInt32 field3;
        public List<SkillDamageMoveEvent> skillDamageMoveEvents;
        public Byte field5;
    }
}
