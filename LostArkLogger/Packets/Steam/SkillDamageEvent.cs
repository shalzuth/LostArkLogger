using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void SteamDecode(BitReader reader)
        {
            CurHp = reader.ReadPackedInt();
            u16_0 = reader.ReadUInt16();
            MaxHp = reader.ReadPackedInt();
            b_0 = reader.ReadByte();
            Damage = reader.ReadPackedInt();
            Modifier = reader.ReadByte();
            TargetId = reader.ReadUInt64();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
        }
    }
}
