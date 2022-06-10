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
            TargetId = reader.ReadUInt64();
            Damage = reader.ReadPackedInt();
            u16 = reader.ReadUInt16();
            MaxHealth = reader.ReadPackedInt();
            CurrentHealth = reader.ReadPackedInt();
            b_2 = reader.ReadByte();
            Modifier = reader.ReadByte();
        }
    }
}
