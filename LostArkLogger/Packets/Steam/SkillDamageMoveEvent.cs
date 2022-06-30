using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageMoveEvent
    {
        public void SteamDecode(BitReader reader)
        {
            u16_0 = reader.ReadUInt16();
            u64_0 = reader.ReadUInt64();
            u16_1 = reader.ReadUInt16();
            flag = reader.ReadFlag();
            u16_2 = reader.ReadUInt16();
            u64_1 = reader.ReadUInt64();
            skillDamageEvent = reader.Read<SkillDamageEvent>();
            u64_2 = reader.ReadUInt64();
            b = reader.ReadByte();
        }
    }
}
