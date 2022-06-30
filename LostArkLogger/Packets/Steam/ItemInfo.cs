using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class ItemInfo
    {
        public void SteamDecode(BitReader reader)
        {
            u16 = reader.ReadUInt16();
            bytearraylist = reader.ReadList<Byte[]>(14);
            s64 = reader.ReadSimpleInt();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
            u32 = reader.ReadUInt32();
            Level = reader.ReadUInt16();
        }
    }
}
