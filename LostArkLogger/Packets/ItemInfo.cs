using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class ItemInfo
    {
        public ItemInfo(BitReader reader)
        {
            field0 = reader.ReadList<Byte[]>(14);
            Level = reader.ReadUInt16();
            hasfield2 = reader.ReadByte();
            if (hasfield2 == 1)
                field2 = reader.ReadByte();
            field3 = reader.ReadUInt16();
            field4 = reader.ReadUInt32();
            field5 = reader.ReadSimpleInt();
        }
        public List<Byte[]> field0;
        public UInt16 Level;
        public Byte hasfield2;
        public Byte field2;
        public UInt16 field3;
        public UInt32 field4;
        public UInt64 field5;
    }
}
