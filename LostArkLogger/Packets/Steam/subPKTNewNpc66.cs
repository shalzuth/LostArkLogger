using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc66
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            b_1 = reader.ReadByte();
            str_0 = reader.ReadString();
            u64_0 = reader.ReadUInt64();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            itemInfos = reader.ReadList<ItemInfo>();
            b_2 = reader.ReadByte();
        }
    }
}
