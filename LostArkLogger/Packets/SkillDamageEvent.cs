using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class SkillDamageEvent
    {
        public SkillDamageEvent(BitReader reader)
        {
            Damage = reader.ReadPackedInt();
            hasfield1 = reader.ReadByte();
            if (hasfield1 == 1)
                field1 = reader.ReadByte();
            field2 = reader.ReadByte();
            field3 = reader.ReadUInt16();
            Modifier = reader.ReadByte();
            CurrentHealth = reader.ReadPackedInt();
            MaxHealth = reader.ReadPackedInt();
            TargetId = reader.ReadUInt64();
        }
        public Int64 Damage;
        public Byte hasfield1;
        public Byte field1;
        public Byte field2;
        public UInt16 field3;
        public Byte Modifier;
        public Int64 CurrentHealth;
        public Int64 MaxHealth;
        public UInt64 TargetId;
    }
}
