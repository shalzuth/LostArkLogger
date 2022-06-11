using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            skillDamageEvents = reader.ReadList<SkillDamageEvent>();
            b = reader.ReadByte();
            SourceId = reader.ReadUInt64();
            SkillEffectId = reader.ReadUInt32();
            SkillId = reader.ReadUInt32();
        }
    }
}
