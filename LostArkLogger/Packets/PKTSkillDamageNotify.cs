using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTSkillDamageNotify
    {
        public PKTSkillDamageNotify(BitReader reader)
        {
            field0 = reader.ReadByte();
            SkillId = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
            SkillEffectId = reader.ReadUInt32();
            skillDamageEvents = reader.ReadList<SkillDamageEvent>();
        }
        public Byte field0;
        public UInt32 SkillId;
        public UInt64 SourceId;
        public UInt32 SkillEffectId;
        public List<SkillDamageEvent> skillDamageEvents;
    }
}
