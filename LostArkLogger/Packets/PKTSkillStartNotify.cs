using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTSkillStartNotify
    {
        public PKTSkillStartNotify(BitReader reader)
        {
            field0 = reader.ReadUInt64();
            hasfield1 = reader.ReadByte();
            if (hasfield1 == 1)
                field1 = reader.ReadUInt32();
            field2 = reader.ReadUInt16();
            field3 = reader.ReadByte();
            field4 = reader.ReadUInt16();
            hasfield5 = reader.ReadByte();
            if (hasfield5 == 1)
                field5 = reader.ReadUInt16();
            field6 = reader.ReadUInt64();
            field7 = reader.ReadPackedValues(1, 1, 4, 4, 4, 3, 6);
            SourceId = reader.ReadUInt64();
            hasfield9 = reader.ReadByte();
            if (hasfield9 == 1)
                field9 = reader.ReadUInt32();
            field10 = reader.ReadUInt64();
            SkillId = reader.ReadUInt32();
        }
        public UInt64 field0;
        public Byte hasfield1;
        public UInt32 field1;
        public UInt16 field2;
        public Byte field3;
        public UInt16 field4;
        public Byte hasfield5;
        public UInt16 field5;
        public UInt64 field6;
        public List<Object> field7;
        public UInt64 SourceId;
        public Byte hasfield9;
        public UInt32 field9;
        public UInt64 field10;
        public UInt32 SkillId;
    }
}
