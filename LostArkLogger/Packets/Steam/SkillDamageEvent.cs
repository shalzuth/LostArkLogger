using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void SteamDecode(BitReader reader)
        {
            CurHp = reader.ReadPackedInt();
            TargetId = reader.ReadUInt64();
            Damage = reader.ReadPackedInt();
            MaxHp = reader.ReadPackedInt();
            u16_0 = reader.ReadUInt16();
            b_0 = reader.ReadByte();
            Modifier = reader.ReadByte();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
        }
    }
}
