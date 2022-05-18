using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct16
    {
        public Struct16(BitReader reader)
        {
            field0 = reader.ReadByte();
            field1 = reader.ReadUInt16();
            field2 = reader.ReadPackedInt();
            field3 = reader.ReadUInt64();
            field4 = reader.ReadByte();
            field5 = reader.ReadByte();
            field6 = reader.ReadPackedInt();
        }
        public Byte field0;
        public UInt16 field1;
        public Int64 field2;
        public UInt64 field3;
        public Byte field4;
        public Byte field5;
        public Int64 field6;
    }
}
