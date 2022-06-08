using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageNotify
    {
        public PKTSkillDamageNotify(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) SteamDecode(reader);
        }
        public Byte field0;
        public UInt32 SkillId;
        public UInt64 SourceId;
        public UInt32 SkillEffectId;
        public List<SkillDamageEvent> skillDamageEvents;
    }
}
