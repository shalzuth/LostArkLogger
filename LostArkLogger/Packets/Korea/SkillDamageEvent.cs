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
            u16 = reader.ReadUInt16();
            CurHp = reader.ReadPackedInt();
            TargetId = reader.ReadUInt64();
            MaxHp = reader.ReadPackedInt();
            b_2 = reader.ReadByte();
        }
    }
}
