using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public void SteamDecode(BitReader reader)
        {
            hasfield0 = reader.ReadByte();
            if (hasfield0 == 1)
                field0 = reader.ReadByte();
            TargetId = reader.ReadUInt64();
            Damage = reader.ReadPackedInt();
            field3 = reader.ReadUInt16();
            MaxHealth = reader.ReadPackedInt();
            CurrentHealth = reader.ReadPackedInt();
            field6 = reader.ReadByte();
            Modifier = reader.ReadByte();
        }
    }
}
