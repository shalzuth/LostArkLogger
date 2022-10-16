using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            MaxHp = reader.ReadPackedInt();
            u16_0 = reader.ReadUInt16();
            Damage = reader.ReadPackedInt();
            Modifier = reader.ReadByte();
            CurHp = reader.ReadPackedInt();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
            TargetId = reader.ReadUInt64();
        }
    }
}
