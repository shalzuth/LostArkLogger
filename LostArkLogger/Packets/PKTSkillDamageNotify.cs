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
        public UInt32 SkillId; //24
        public UInt64 SourceId; //32
        public UInt32 SkillEffectId; //40
        public Byte field3; //44
        public SkillDamageEvents skillDamageEvents; //45
    }
}
