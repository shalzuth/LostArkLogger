using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTSkillDamageNotify
    {
        public PKTSkillDamageNotify(BitReader reader)
        {
            SkillEffectId = reader.ReadUInt32();
            field1 = reader.ReadByte();
            SkillId = reader.ReadUInt32();
            skillDamageEvents = new SkillDamageEvents(reader);
            SourceId = reader.ReadUInt64();
        }
        public UInt32 SkillEffectId;
        public Byte field1;
        public UInt32 SkillId;
        public SkillDamageEvents skillDamageEvents;
        public UInt64 SourceId;
    }
}
