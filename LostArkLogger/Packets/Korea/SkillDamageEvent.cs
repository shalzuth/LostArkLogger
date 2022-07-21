using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void KoreaDecode(BitReader reader)
        {
            Modifier = reader.ReadByte();
            b_0 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
            CurHp = reader.ReadPackedInt();
            Damage = reader.ReadPackedInt();
            TargetId = reader.ReadUInt64();
            MaxHp = reader.ReadPackedInt();
        }
    }
}
