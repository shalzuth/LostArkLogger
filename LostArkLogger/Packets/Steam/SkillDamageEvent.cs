using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void SteamDecode(BitReader reader)
        {
            u16_0 = reader.ReadUInt16();
            MaxHp = reader.ReadPackedInt();
            Damage = reader.ReadPackedInt();
            Modifier = reader.ReadByte();
            b_0 = reader.ReadByte();
            CurHp = reader.ReadPackedInt();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
            TargetId = reader.ReadUInt64();
        }
    }
}
