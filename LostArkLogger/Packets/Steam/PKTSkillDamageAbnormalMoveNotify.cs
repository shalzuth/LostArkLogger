using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageAbnormalMoveNotify
    {
        public void SteamDecode(BitReader reader)
        {
            SkillId = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
            SkillEffectId = reader.ReadUInt32();
            u32_0 = reader.ReadUInt32();
            skillDamageMoveEvents = reader.ReadList<SkillDamageMoveEvent>();
            b_0 = reader.ReadByte();
        }
    }
}
