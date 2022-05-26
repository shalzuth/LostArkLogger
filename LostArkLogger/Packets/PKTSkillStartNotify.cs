using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTSkillStartNotify
    {
        public PKTSkillStartNotify(BitReader reader)
        {
            hasfield0 = reader.ReadByte();
            if (hasfield0 == 1)
                field0 = reader.ReadUInt32();
            SkillId = reader.ReadUInt32();
            hasfield2 = reader.ReadByte();
            if (hasfield2 == 1)
                field2 = reader.ReadUInt16();
            field3 = reader.ReadPackedValues(1, 1, 4, 4, 4, 3, 6);
            hasfield4 = reader.ReadByte();
            if (hasfield4 == 1)
                field4 = reader.ReadUInt32();
            field5 = reader.ReadUInt64();
            field6 = reader.ReadByte();
            field7 = reader.ReadUInt16();
            SourceId = reader.ReadUInt64();
            field9 = reader.ReadUInt16();
            field10 = reader.ReadUInt64();
            field11 = reader.ReadUInt64();
        }
        public Byte hasfield0;
        public UInt32 field0;
        public UInt32 SkillId;
        public Byte hasfield2;
        public UInt16 field2;
        public List<Object> field3;
        public Byte hasfield4;
        public UInt32 field4;
        public UInt64 field5;
        public Byte field6;
        public UInt16 field7;
        public UInt64 SourceId;
        public UInt16 field9;
        public UInt64 field10;
        public UInt64 field11;
    }
}
