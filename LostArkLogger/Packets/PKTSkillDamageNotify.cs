using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTSkillDamageNotify
    {
        public PKTSkillDamageNotify(BitReader reader)
        {
            SkillId = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
            SkillEffectId = reader.ReadUInt32();
            field3 = reader.ReadByte();
            skillDamageEvents = new SkillDamageEvents(reader);
        }
        public UInt32 SkillId;
        public UInt64 SourceId;
        public UInt32 SkillEffectId;
        public Byte field3;
        public SkillDamageEvents skillDamageEvents;
    }
}
