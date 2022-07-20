using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void SteamDecode(BitReader reader)
        {
            CurHp = reader.ReadPackedInt();
            MaxHp = reader.ReadPackedInt();
            Damage = reader.ReadPackedInt();
            b_0 = reader.ReadByte();
            u16 = reader.ReadUInt16();
            Modifier = reader.ReadByte();
            TargetId = reader.ReadUInt64();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
        }
    }
}
