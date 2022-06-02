using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewNpc_1_2
    {
        public PKTNewNpc_1_2(BitReader reader)
        {
            field0 = reader.ReadByte();
            field1 = reader.ReadUInt16();
            field2 = reader.ReadString();
            field3 = reader.ReadByte();
            field4 = reader.ReadUInt64();
            field5 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            pKTNewNpc_1_2_2 = reader.Read<PKTNewNpc_1_2_2>();
        }
        public Byte field0;
        public UInt16 field1;
        public String field2;
        public Byte field3;
        public UInt64 field4;
        public Byte field5;
        public List<ItemInfo> itemInfos;
        public PKTNewNpc_1_2_2 pKTNewNpc_1_2_2;
    }
}
