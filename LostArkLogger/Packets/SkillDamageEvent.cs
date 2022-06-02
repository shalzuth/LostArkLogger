using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class SkillDamageEvent
    {
        public SkillDamageEvent(BitReader reader)
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
        public Byte hasfield0;
        public Byte field0;
        public UInt64 TargetId;
        public Int64 Damage;
        public UInt16 field3;
        public Int64 MaxHealth;
        public Int64 CurrentHealth;
        public Byte field6;
        public Byte Modifier;
    }
}
