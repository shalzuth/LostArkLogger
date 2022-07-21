using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageMoveEvent
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            flag_1 = reader.ReadUInt64();
            skillDamageEvent = reader.Read<SkillDamageEvent>();
            u16_1 = reader.ReadUInt16();
            flag_2 = reader.ReadUInt64();
            flag_0 = reader.ReadFlag();
            flag_3 = reader.ReadUInt64();
            u16_2 = reader.ReadUInt16();
        }
    }
}
