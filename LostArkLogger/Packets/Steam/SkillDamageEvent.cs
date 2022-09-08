using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void SteamDecode(BitReader reader)
        {
            TargetId = reader.ReadUInt64();
            CurHp = reader.ReadPackedInt();
            Damage = reader.ReadPackedInt();
            u16_0 = reader.ReadUInt16();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
            Modifier = reader.ReadByte();
            b_2 = reader.ReadByte();
            MaxHp = reader.ReadPackedInt();
        }
    }
}
