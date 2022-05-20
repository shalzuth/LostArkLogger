using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewNpc_1_5_1
    {
        public PKTNewNpc_1_5_1(BitReader reader)
        {
            field0 = reader.ReadByte();
            field1 = reader.ReadUInt64();
            field2 = reader.ReadUInt16();
            field3 = reader.ReadPackedInt();
            field4 = reader.ReadPackedInt();
            field5 = reader.ReadByte();
            field6 = reader.ReadByte();
        }
        public Byte field0;
        public UInt64 field1;
        public UInt16 field2;
        public Int64 field3;
        public Int64 field4;
        public Byte field5;
        public Byte field6;
    }
}
