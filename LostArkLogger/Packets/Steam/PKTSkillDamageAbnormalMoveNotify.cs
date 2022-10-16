using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageAbnormalMoveNotify
    {
        public void SteamDecode(BitReader reader)
        {
            skillDamageMoveEvents = reader.ReadList<SkillDamageMoveEvent>();
            u32_0 = reader.ReadUInt32();
            SkillEffectId = reader.ReadUInt32();
            SkillId = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
        }
    }
}
