using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewPC_1
    {
        public PKTNewPC_1(BitReader reader)
        {
            field0 = reader.ReadUInt32();
            field1 = reader.ReadBytes(12);
            field2 = reader.ReadUInt32();
            hasfield3 = reader.ReadByte();
            if (hasfield3 == 1)
                field3 = reader.ReadBytes(12);
        }
        public UInt32 field0;
        public Byte[] field1;
        public UInt32 field2;
        public Byte hasfield3;
        public Byte[] field3;
    }
}
