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
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            b_2 = reader.ReadByte();
            u64 = reader.ReadUInt64();
            u16 = reader.ReadUInt16();
            itemInfos = reader.ReadList<ItemInfo>();
            str = reader.ReadString();
        }
    }
}
