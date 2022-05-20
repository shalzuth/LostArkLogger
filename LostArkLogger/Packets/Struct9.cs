using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct9
    {
        public Struct9(BitReader reader)
        {
            field0 = new Struct10(reader);
            field1 = reader.ReadUInt16();
            hasfield2 = reader.ReadByte();
            if (hasfield2 == 1)
                field2 = reader.ReadByte();
            field3 = reader.ReadUInt16();
            field4 = reader.ReadUInt32();
            field5 = reader.ReadSimpleInt();
        }
        public Struct10 field0;
        public UInt16 field1;
        public Byte hasfield2;
        public Byte field2;
        public UInt16 field3;
        public UInt32 field4;
        public UInt64 field5;
    }
}
