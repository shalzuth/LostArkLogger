using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageAbnormalMoveNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            SkillEffectId = reader.ReadUInt32();
            skillDamageMoveEvents = reader.ReadList<SkillDamageMoveEvent>();
            SourceId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            u32_0 = reader.ReadUInt32();
            SkillId = reader.ReadUInt32();
        }
    }
}
