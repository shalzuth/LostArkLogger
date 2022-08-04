using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            skillDamageEvents = reader.ReadList<SkillDamageEvent>();
            SourceId = reader.ReadUInt64();
            SkillEffectId = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            SkillId = reader.ReadUInt32();
        }
    }
}
