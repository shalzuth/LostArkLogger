using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class SkillDamageMoveEvent
    {
        public SkillDamageMoveEvent(BitReader reader)
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
        public UInt64 field0;
        public Byte field1;
        public UInt64 field2;
        public UInt16 field3;
        public SkillDamageEvent skillDamageEvent;
        public UInt16 field5;
        public UInt16 field6;
        public UInt64 field7;
        public UInt64 field8;
    }
}
