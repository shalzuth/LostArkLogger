using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTSkillDamageAbnormalMoveNotify
    {
        public PKTSkillDamageAbnormalMoveNotify(BitReader reader)
        {
            SourceId = reader.ReadUInt64();
            SkillEffectId = reader.ReadUInt32();
            field2 = reader.ReadByte();
            skillDamageMoveEvents = new SkillDamageMoveEvents(reader);
            SkillId = reader.ReadUInt32();
        }
        public UInt64 SourceId;
        public UInt32 SkillEffectId;
        public Byte field2;
        public SkillDamageMoveEvents skillDamageMoveEvents;
        public UInt32 SkillId;
    }
}
