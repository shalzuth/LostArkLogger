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
        public Byte field0; //0
        public UInt16 field1; //2
        public Int64 field2; //8
        public UInt64 field3; //24
        public Byte field4; //32
        public Byte field5; //33
        public Int64 field6; //40
    }
}
