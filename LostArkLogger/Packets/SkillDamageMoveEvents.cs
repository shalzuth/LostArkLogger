using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class SkillDamageMoveEvents
    {
        public SkillDamageMoveEvents(BitReader reader)
        {
            field0 = reader.ReadFlag();
            field1 = reader.ReadByte();
            field2 = reader.ReadUInt64();
            field3 = reader.ReadUInt16();
            skillDamageEvent = new SkillDamageEvent(reader);
            field5 = reader.ReadUInt16();
            field6 = reader.ReadUInt16();
            field7 = reader.ReadUInt64();
            field8 = reader.ReadUInt64();
        }
        public UInt64 field0; //0
        public Byte field1; //32
        public UInt64 field2; //33
        public UInt16 field3; //42
        public SkillDamageEvent skillDamageEvent; //48
        public UInt16 field5; //112
        public UInt16 field6; //114
        public UInt64 field7; //116
        public UInt64 field8; //128
    }
}
