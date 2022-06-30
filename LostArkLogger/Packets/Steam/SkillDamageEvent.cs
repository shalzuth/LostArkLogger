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
            Damage = reader.ReadPackedInt();
            TargetId = reader.ReadUInt64();
            MaxHealth = reader.ReadPackedInt();
            CurrentHealth = reader.ReadPackedInt();
            u16 = reader.ReadUInt16();
            b_2 = reader.ReadByte();
        }
    }
}
