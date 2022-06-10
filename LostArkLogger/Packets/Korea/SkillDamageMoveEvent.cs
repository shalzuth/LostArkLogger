using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageMoveEvent
    {
        public void KoreaDecode(BitReader reader)
        {
            u64_0 = reader.ReadUInt64();
            flag = reader.ReadFlag();
            u16_0 = reader.ReadUInt16();
            b = reader.ReadByte();
            u16_1 = reader.ReadUInt16();
            u64_1 = reader.ReadUInt64();
            u64_2 = reader.ReadUInt64();
            u16_2 = reader.ReadUInt16();
            skillDamageEvent = reader.Read<SkillDamageEvent>();
        }
    }
}
