using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc66
    {
        public void SteamDecode(BitReader reader)
        {
            u16_0 = reader.ReadUInt16();
            u64_0 = reader.ReadUInt64();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            b_2 = reader.ReadByte();
            str_0 = reader.ReadString();
        }
    }
}
