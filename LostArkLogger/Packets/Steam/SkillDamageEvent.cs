using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            Modifier = reader.ReadByte();
            b_2 = reader.ReadByte();
            CurHp = reader.ReadPackedInt();
            Damage = reader.ReadPackedInt();
            MaxHp = reader.ReadPackedInt();
            TargetId = reader.ReadUInt64();
        }
    }
}
