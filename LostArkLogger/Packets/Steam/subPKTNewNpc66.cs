using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc66
    {
        public void SteamDecode(BitReader reader)
        {
            u16_0 = reader.ReadUInt16();
            b_0 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            str_0 = reader.ReadString();
        }
    }
}
