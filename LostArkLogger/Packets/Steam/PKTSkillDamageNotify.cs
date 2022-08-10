using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageNotify
    {
        public void SteamDecode(BitReader reader)
        {
            SkillId = reader.ReadUInt32();
            skillDamageEvents = reader.ReadList<SkillDamageEvent>();
            b_0 = reader.ReadByte();
            SkillEffectId = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
        }
    }
}
