using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTSkillDamageAbnormalMoveNotify
    {
        public PKTSkillDamageAbnormalMoveNotify(BitReader reader)
        {
            SkillEffectId = reader.ReadUInt32();
            SkillId = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
            field3 = reader.ReadUInt32();
            skillDamageMoveEvents = reader.ReadList<SkillDamageMoveEvent>();
            field5 = reader.ReadByte();
        }
        public UInt32 SkillEffectId;
        public UInt32 SkillId;
        public UInt64 SourceId;
        public UInt32 field3;
        public List<SkillDamageMoveEvent> skillDamageMoveEvents;
        public Byte field5;
    }
}
