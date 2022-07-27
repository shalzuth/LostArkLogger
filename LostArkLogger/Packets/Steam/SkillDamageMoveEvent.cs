using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageMoveEvent
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            flag_1 = reader.ReadUInt64();
            flag_0 = reader.ReadFlag();
            u16_1 = reader.ReadUInt16();
            u16_2 = reader.ReadUInt16();
            flag_2 = reader.ReadUInt64();
            skillDamageEvent = reader.Read<SkillDamageEvent>();
            flag_3 = reader.ReadUInt64();
        }
    }
}
