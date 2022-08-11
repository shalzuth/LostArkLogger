using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class ItemInfo
    {
        public void KoreaDecode(BitReader reader)
        {
            bytearraylist_0 = reader.ReadList<Byte[]>(14);
            u32_0 = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
            Level = reader.ReadUInt16();
            s64_0 = reader.ReadSimpleInt();
            u16_0 = reader.ReadUInt16();
        }
    }
}
