using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            SkillId = reader.ReadUInt32();
            SkillEffectId = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            SourceId = reader.ReadUInt64();
            skillDamageEvents = reader.ReadList<SkillDamageEvent>();
        }
    }
}
