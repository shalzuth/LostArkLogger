using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class SkillDamageMoveEvent
    {
        public SkillDamageMoveEvent(BitReader reader)
        {
            field0 = reader.ReadUInt16();
            field1 = reader.ReadUInt64();
            field2 = reader.ReadUInt16();
            field3 = reader.ReadUInt64();
            skillDamageEvent = reader.Read<SkillDamageEvent>();
            field5 = reader.ReadFlag();
            field6 = reader.ReadUInt64();
            field7 = reader.ReadByte();
            field8 = reader.ReadUInt16();
        }
        public UInt16 field0;
        public UInt64 field1;
        public UInt16 field2;
        public UInt64 field3;
        public SkillDamageEvent skillDamageEvent;
        public UInt64 field5;
        public UInt64 field6;
        public Byte field7;
        public UInt16 field8;
    }
}
