using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct8
    {
        public Struct8(BitReader reader)
        {
            field0 = new Struct9(reader);
            field1 = reader.ReadUInt32();
            field2 = reader.ReadUInt16();
            field3 = reader.ReadUInt16();
            field4 = reader.ReadSimpleInt();
        }
        public Struct9 field0;
        public UInt32 field1;
        public UInt16 field2;
        public UInt16 field3;
        public UInt64 field4;
    }
}
