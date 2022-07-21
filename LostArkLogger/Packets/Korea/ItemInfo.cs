using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class ItemInfo
    {
        public void KoreaDecode(BitReader reader)
        {
            u32_0 = reader.ReadUInt32();
            s64_0 = reader.ReadSimpleInt();
            bytearraylist_0 = reader.ReadList<Byte[]>(14);
            Level = reader.ReadUInt16();
            u16_0 = reader.ReadUInt16();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
        }
    }
}
