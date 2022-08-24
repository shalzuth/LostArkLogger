using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageMoveEvent
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            flag_0 = reader.ReadFlag();
            u16_0 = reader.ReadUInt16();
            skillDamageEvent = reader.Read<SkillDamageEvent>();
            flag_1 = reader.ReadUInt64();
            flag_2 = reader.ReadUInt64();
            u16_1 = reader.ReadUInt16();
            flag_3 = reader.ReadUInt64();
            u16_2 = reader.ReadUInt16();
        }
    }
}
