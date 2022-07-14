using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageAbnormalMoveNotify
    {
        public PKTSkillDamageAbnormalMoveNotify(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
        }
        public UInt64 SourceId;
        public UInt32 SkillEffectId;
        public UInt32 SkillId;
        public List<SkillDamageMoveEvent> skillDamageMoveEvents;
        public UInt32 u32;
        public Byte b;
    }
}
