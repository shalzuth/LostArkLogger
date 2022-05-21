using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewNpc_1_1
    {
        public PKTNewNpc_1_1(BitReader reader)
        {
            field0 = reader.ReadByte();
            field1 = reader.ReadByte();
            field2 = reader.ReadString();
            pKTNewNpc_1_1_1 = reader.Read<PKTNewNpc_1_1_1>();
            itemInfos = reader.ReadList<ItemInfo>();
            field5 = reader.ReadByte();
            field6 = reader.ReadUInt64();
            field7 = reader.ReadUInt16();
        }
        public Byte field0;
        public Byte field1;
        public String field2;
        public PKTNewNpc_1_1_1 pKTNewNpc_1_1_1;
        public List<ItemInfo> itemInfos;
        public Byte field5;
        public UInt64 field6;
        public UInt16 field7;
    }
}
