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
            itemInfos = reader.ReadList<ItemInfo>();
            str_0 = reader.ReadString();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
        }
    }
}
