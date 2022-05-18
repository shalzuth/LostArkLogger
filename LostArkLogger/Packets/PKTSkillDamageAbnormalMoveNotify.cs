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
            skillDamageMoveEvent = new SkillDamageMoveEvent(reader);
            SkillId = reader.ReadUInt32();
        }
        public UInt64 SourceId; //24
        public UInt32 SkillEffectId; //32
        public Byte field2; //36
        public SkillDamageMoveEvent skillDamageMoveEvent; //37
        public UInt32 SkillId; //6840
    }
}
