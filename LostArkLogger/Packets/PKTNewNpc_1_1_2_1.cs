using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewNpc_1_1_2_1
    {
        public PKTNewNpc_1_1_2_1(BitReader reader)
        {
            field0 = reader.ReadList<Byte[]>(14);
            field1 = reader.ReadUInt16();
            hasfield2 = reader.ReadByte();
            if (hasfield2 == 1)
                field2 = reader.ReadByte();
            field3 = reader.ReadUInt16();
            field4 = reader.ReadUInt32();
            field5 = reader.ReadSimpleInt();
        }
        public List<Byte[]> field0;
        public UInt16 field1;
        public Byte hasfield2;
        public Byte field2;
        public UInt16 field3;
        public UInt32 field4;
        public UInt64 field5;
    }
}
