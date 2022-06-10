using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class ItemInfo
    {
        public void KoreaDecode(BitReader reader)
        {
            u32 = reader.ReadUInt32();
            u16 = reader.ReadUInt16();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
            bytearraylist = reader.ReadList<Byte[]>(14);
            s64 = reader.ReadSimpleInt();
            Level = reader.ReadUInt16();
        }
    }
}
