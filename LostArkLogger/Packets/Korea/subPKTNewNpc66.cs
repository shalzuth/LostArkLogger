using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc66
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            u16 = reader.ReadUInt16();
            u64 = reader.ReadUInt64();
            str = reader.ReadString();
        }
    }
}
