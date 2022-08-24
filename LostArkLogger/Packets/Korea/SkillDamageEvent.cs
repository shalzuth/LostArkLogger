using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void KoreaDecode(BitReader reader)
        {
            MaxHp = reader.ReadPackedInt();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
            TargetId = reader.ReadUInt64();
            b_2 = reader.ReadByte();
            CurHp = reader.ReadPackedInt();
            u16_0 = reader.ReadUInt16();
            Damage = reader.ReadPackedInt();
            Modifier = reader.ReadByte();
        }
    }
}
