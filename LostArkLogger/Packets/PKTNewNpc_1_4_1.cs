using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewNpc_1_4_1
    {
        public PKTNewNpc_1_4_1(BitReader reader)
        {
            field0 = reader.ReadUInt16();
            field1 = reader.ReadPackedInt();
            field2 = reader.ReadUInt64();
            field3 = reader.ReadByte();
            field4 = reader.ReadPackedInt();
            field5 = reader.ReadByte();
            field6 = reader.ReadByte();
        }
        public UInt16 field0;
        public Int64 field1;
        public UInt64 field2;
        public Byte field3;
        public Int64 field4;
        public Byte field5;
        public Byte field6;
    }
}
