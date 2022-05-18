using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct5
    {
        public Struct5(BitReader reader)
        {
            field0 = reader.ReadUInt32();
            hasfield1 = reader.ReadByte();
            if (hasfield1 == 1)
                field1 = reader.ReadBytes(12);
            field2 = reader.ReadBytes(12);
            field3 = reader.ReadUInt32();
        }
        public UInt32 field0; //0
        public Byte hasfield1; //16
        public Byte[] field1; //4
        public Byte[] field2; //20
        public UInt32 field3; //32
    }
}
