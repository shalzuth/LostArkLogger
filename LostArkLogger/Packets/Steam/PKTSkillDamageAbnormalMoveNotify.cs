using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageAbnormalMoveNotify
    {
        public void SteamDecode(BitReader reader)
        {
            SkillEffectId = reader.ReadUInt32();
            skillDamageMoveEvents = reader.ReadList<SkillDamageMoveEvent>();
            SkillId = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
            u32 = reader.ReadUInt32();
            b = reader.ReadByte();
        }
    }
}
