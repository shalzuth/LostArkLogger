using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct13
    {
        public Struct13(BitReader reader)
        {
            field0 = reader.ReadUInt32();
            field1 = reader.ReadUInt32();
            field2 = reader.ReadSimpleInt();
            field3 = reader.ReadUInt32();
            field4 = reader.ReadUInt64();
            hasfield5 = reader.ReadByte();
            if (hasfield5 == 1)
                field5 = reader.ReadUInt64();
            field6 = reader.ReadByte();
            field7 = reader.ReadUInt64();
            hasfield8 = reader.ReadByte();
            if (hasfield8 == 1)
                field8 = reader.ReadBytes(16);
            field9 = new Struct14(reader);
            field10 = reader.ReadByte();
        }
        public UInt32 field0;
        public UInt32 field1;
        public UInt64 field2;
        public UInt32 field3;
        public UInt64 field4;
        public Byte hasfield5;
        public UInt64 field5;
        public Byte field6;
        public UInt64 field7;
        public Byte hasfield8;
        public Byte[] field8;
        public Struct14 field9;
        public Byte field10;
    }
}
