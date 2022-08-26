using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageAbnormalMoveNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            SkillEffectId = reader.ReadUInt32();
            u32_0 = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            SkillId = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
            skillDamageMoveEvents = reader.ReadList<SkillDamageMoveEvent>();
        }
    }
}
