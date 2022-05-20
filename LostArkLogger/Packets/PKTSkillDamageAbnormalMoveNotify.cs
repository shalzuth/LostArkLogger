using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTSkillDamageAbnormalMoveNotify
    {
        public PKTSkillDamageAbnormalMoveNotify(BitReader reader)
        {
            SkillId = reader.ReadUInt32();
            field1 = reader.ReadByte();
            field2 = reader.ReadUInt32();
            SkillEffectId = reader.ReadUInt32();
            skillDamageMoveEvents = reader.ReadList<SkillDamageMoveEvent>();
            SourceId = reader.ReadUInt64();
        }
        public UInt32 SkillId;
        public Byte field1;
        public UInt32 field2;
        public UInt32 SkillEffectId;
        public List<SkillDamageMoveEvent> skillDamageMoveEvents;
        public UInt64 SourceId;
    }
}
