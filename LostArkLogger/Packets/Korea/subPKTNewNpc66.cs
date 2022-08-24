using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc66
    {
        public void KoreaDecode(BitReader reader)
        {
            str_0 = reader.ReadString();
            u16_0 = reader.ReadUInt16();
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            itemInfos = reader.ReadList<ItemInfo>();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            b_2 = reader.ReadByte();
        }
    }
}
