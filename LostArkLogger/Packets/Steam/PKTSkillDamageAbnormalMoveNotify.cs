using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageAbnormalMoveNotify
    {
        public void SteamDecode(BitReader reader)
        {
            skillDamageMoveEvents = reader.ReadList<SkillDamageMoveEvent>();
            SourceId = reader.ReadUInt64();
            SkillId = reader.ReadUInt32();
            u32_0 = reader.ReadUInt32();
            SkillEffectId = reader.ReadUInt32();
            b_0 = reader.ReadByte();
        }
    }
}
