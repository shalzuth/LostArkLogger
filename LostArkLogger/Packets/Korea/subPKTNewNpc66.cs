using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc66
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            b_1 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            str_0 = reader.ReadString();
            u16_0 = reader.ReadUInt16();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            b_2 = reader.ReadByte();
        }
    }
}
