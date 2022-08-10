using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc66
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            u64_0 = reader.ReadUInt64();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            str_0 = reader.ReadString();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
        }
    }
}
