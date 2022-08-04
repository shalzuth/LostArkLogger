using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void KoreaDecode(BitReader reader)
        {
            TargetId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            Damage = reader.ReadPackedInt();
            CurHp = reader.ReadPackedInt();
            MaxHp = reader.ReadPackedInt();
            Modifier = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
        }
    }
}
