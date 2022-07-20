using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc66
    {
        public void SteamDecode(BitReader reader)
        {
            u16 = reader.ReadUInt16();
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            u64 = reader.ReadUInt64();
            itemInfos = reader.ReadList<ItemInfo>();
            str = reader.ReadString();
        }
    }
}
