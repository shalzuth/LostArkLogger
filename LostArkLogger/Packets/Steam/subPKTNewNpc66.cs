using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc66
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            b_1 = reader.ReadByte();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            u64 = reader.ReadUInt64();
            str = reader.ReadString();
            b_2 = reader.ReadByte();
            u16 = reader.ReadUInt16();
        }
    }
}
