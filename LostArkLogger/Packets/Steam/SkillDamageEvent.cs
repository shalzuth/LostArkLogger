using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void SteamDecode(BitReader reader)
        {
            Modifier = reader.ReadByte();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            MaxHp = reader.ReadPackedInt();
            CurHp = reader.ReadPackedInt();
            TargetId = reader.ReadUInt64();
            b_2 = reader.ReadByte();
            Damage = reader.ReadPackedInt();
        }
    }
}
