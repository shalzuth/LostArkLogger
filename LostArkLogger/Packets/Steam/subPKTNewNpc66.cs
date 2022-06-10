using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc66
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            u16 = reader.ReadUInt16();
            str = reader.ReadString();
            b_1 = reader.ReadByte();
            u64 = reader.ReadUInt64();
            b_2 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
        }
    }
}
