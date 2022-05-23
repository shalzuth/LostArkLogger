using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class SkillDamageEvent
    {
        public SkillDamageEvent(BitReader reader)
        {
            Damage = reader.ReadPackedInt();
            CurrentHealth = reader.ReadPackedInt();
            Modifier = reader.ReadByte();
            TargetId = reader.ReadUInt64();
            hasfield4 = reader.ReadByte();
            if (hasfield4 == 1)
                field4 = reader.ReadByte();
            field5 = reader.ReadByte();
            MaxHealth = reader.ReadPackedInt();
            field7 = reader.ReadUInt16();
        }
        public Int64 Damage;
        public Int64 CurrentHealth;
        public Byte Modifier;
        public UInt64 TargetId;
        public Byte hasfield4;
        public Byte field4;
        public Byte field5;
        public Int64 MaxHealth;
        public UInt16 field7;
    }
}
