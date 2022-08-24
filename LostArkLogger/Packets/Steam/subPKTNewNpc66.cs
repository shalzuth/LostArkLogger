using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc66
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            u64_0 = reader.ReadUInt64();
            str_0 = reader.ReadString();
            u16_0 = reader.ReadUInt16();
            itemInfos = reader.ReadList<ItemInfo>();
            b_2 = reader.ReadByte();
        }
    }
}
