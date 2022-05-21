using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewPC_2
    {
        public PKTNewPC_2(BitReader reader)
        {
            field0 = reader.ReadBytes(12);
            hasfield1 = reader.ReadByte();
            if (hasfield1 == 1)
                field1 = reader.ReadBytes(12);
            field2 = reader.ReadUInt32();
            field3 = reader.ReadUInt32();
        }
        public Byte[] field0;
        public Byte hasfield1;
        public Byte[] field1;
        public UInt32 field2;
        public UInt32 field3;
    }
}
