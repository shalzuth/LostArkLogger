using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageMoveEvent
    {
        public void SteamDecode(BitReader reader)
        {
            u64_0 = reader.ReadUInt64();
            u64_1 = reader.ReadUInt64();
            b = reader.ReadByte();
            skillDamageEvent = reader.Read<SkillDamageEvent>();
            u16_0 = reader.ReadUInt16();
            u16_1 = reader.ReadUInt16();
            flag = reader.ReadFlag();
            u64_2 = reader.ReadUInt64();
            u16_2 = reader.ReadUInt16();
        }
    }
}
