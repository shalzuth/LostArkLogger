using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageAbnormalMoveNotify
    {
        public void SteamDecode(BitReader reader)
        {
            SourceId = reader.ReadUInt64();
            skillDamageMoveEvents = reader.ReadList<SkillDamageMoveEvent>();
            SkillEffectId = reader.ReadUInt32();
            u32 = reader.ReadUInt32();
            SkillId = reader.ReadUInt32();
            b = reader.ReadByte();
        }
    }
}
