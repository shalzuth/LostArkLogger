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
            field4 = reader.ReadUInt16();
            field5 = reader.ReadUInt64();
            field6 = reader.ReadUInt64();
            skillDamageEvent = reader.Read<SkillDamageEvent>();
            field8 = reader.ReadUInt16();
        }
        public UInt64 field0;
        public Byte field1;
        public UInt64 field2;
        public UInt16 field3;
        public UInt16 field4;
        public UInt64 field5;
        public UInt64 field6;
        public SkillDamageEvent skillDamageEvent;
        public UInt16 field8;
    }
}
