using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageNotify
    {
        public void SteamDecode(BitReader reader)
        {
            SourceId = reader.ReadUInt64();
            SkillEffectId = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            SkillId = reader.ReadUInt32();
            skillDamageEvents = reader.ReadList<SkillDamageEvent>();
        }
    }
}
