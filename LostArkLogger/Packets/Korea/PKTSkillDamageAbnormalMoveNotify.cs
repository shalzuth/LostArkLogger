using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageAbnormalMoveNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            skillDamageMoveEvents = reader.ReadList<SkillDamageMoveEvent>();
            SourceId = reader.ReadUInt64();
            u32 = reader.ReadUInt32();
            SkillEffectId = reader.ReadUInt32();
            SkillId = reader.ReadUInt32();
            b = reader.ReadByte();
        }
    }
}
