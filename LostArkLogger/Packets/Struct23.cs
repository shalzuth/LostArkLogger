using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct23
    {
        public Struct23(BitReader reader)
        {
            field0 = reader.ReadByte();
            field1 = reader.ReadByte();
            field2 = reader.ReadString();
            field3 = new Struct11(reader);
            field4 = new Struct12(reader);
            field5 = reader.ReadByte();
            field6 = reader.ReadUInt64();
            field7 = reader.ReadUInt16();
        }
        public Byte field0;
        public Byte field1;
        public String field2;
        public Struct11 field3;
        public Struct12 field4;
        public Byte field5;
        public UInt64 field6;
        public UInt16 field7;
    }
}
