using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageMoveEvent
    {
        public void SteamDecode(BitReader reader)
        {
            flag_1 = reader.ReadUInt64();
            u16_0 = reader.ReadUInt16();
            b_0 = reader.ReadByte();
            flag_2 = reader.ReadUInt64();
            flag_3 = reader.ReadUInt64();
            u16_1 = reader.ReadUInt16();
            flag_0 = reader.ReadFlag();
            u16_2 = reader.ReadUInt16();
            skillDamageEvent = reader.Read<SkillDamageEvent>();
        }
    }
}
