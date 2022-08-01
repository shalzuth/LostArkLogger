using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void KoreaDecode(BitReader reader)
        {
            Modifier = reader.ReadByte();
            Damage = reader.ReadPackedInt();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
            TargetId = reader.ReadUInt64();
            MaxHp = reader.ReadPackedInt();
            CurHp = reader.ReadPackedInt();
            b_2 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
        }
    }
}
