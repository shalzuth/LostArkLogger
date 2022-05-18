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
        public Int64 Damage; //0
        public Byte hasfield1; //17
        public Byte field1; //16
        public Byte field2; //18
        public UInt16 field3; //20
        public Byte Modifier; //22
        public Int64 CurrentHealth; //24
        public Int64 MaxHealth; //40
        public UInt64 TargetId; //56
    }
}
