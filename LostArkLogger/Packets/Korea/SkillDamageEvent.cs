using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            TargetId = reader.ReadUInt64();
            CurrentHealth = reader.ReadPackedInt();
            MaxHealth = reader.ReadPackedInt();
            u16 = reader.ReadUInt16();
            Modifier = reader.ReadByte();
            Damage = reader.ReadPackedInt();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
        }
    }
}
