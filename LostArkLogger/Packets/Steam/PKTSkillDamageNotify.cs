using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageNotify
    {
        public void SteamDecode(BitReader reader)
        {
            SkillEffectId = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            skillDamageEvents = reader.ReadList<SkillDamageEvent>();
            SkillId = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
        }
    }
}
