using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillDamageAbnormalMoveNotify
    {
        public void SteamDecode(BitReader reader)
        {
            SkillEffectId = reader.ReadUInt32();
            SkillId = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
            field3 = reader.ReadUInt32();
            skillDamageMoveEvents = reader.ReadList<SkillDamageMoveEvent>();
            field5 = reader.ReadByte();
        }
    }
}
