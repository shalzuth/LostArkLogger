using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class ItemInfo
    {
        public ItemInfo(BitReader reader)
        {
            field0 = reader.ReadList<Byte[]>(14);
            hasfield1 = reader.ReadByte();
            if (hasfield1 == 1)
                field1 = reader.ReadByte();
            field2 = reader.ReadUInt32();
            field3 = reader.ReadUInt16();
            field4 = reader.ReadSimpleInt();
            Level = reader.ReadUInt16();
        }
        public List<Byte[]> field0;
        public Byte hasfield1;
        public Byte field1;
        public UInt32 field2;
        public UInt16 field3;
        public UInt64 field4;
        public UInt16 Level;
    }
}
