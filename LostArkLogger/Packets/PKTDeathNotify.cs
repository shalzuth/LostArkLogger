using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTDeathNotify
    {
        public PKTDeathNotify(BitReader reader)
        {
            field0 = reader.ReadUInt32();
            field1 = reader.ReadByte();
            field2 = reader.ReadUInt16();
            hasfield3 = reader.ReadByte();
            if (hasfield3 == 1)
                field3 = reader.ReadByte();
            field4 = reader.ReadUInt64();
            hasfield5 = reader.ReadByte();
            if (hasfield5 == 1)
                field5 = reader.ReadByte();
            field6 = reader.ReadUInt64();
            field7 = reader.ReadUInt64();
            hasfield8 = reader.ReadByte();
            if (hasfield8 == 1)
                field8 = reader.ReadByte();
        }
        public UInt32 field0;
        public Byte field1;
        public UInt16 field2;
        public Byte hasfield3;
        public Byte field3;
        public UInt64 field4;
        public Byte hasfield5;
        public Byte field5;
        public UInt64 field6;
        public UInt64 field7;
        public Byte hasfield8;
        public Byte field8;
    }
}
