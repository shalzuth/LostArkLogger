using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc66
    {
        public void SteamDecode(BitReader reader)
        {
            itemInfos = reader.ReadList<ItemInfo>();
            b_0 = reader.ReadByte();
            str_0 = reader.ReadString();
            b_1 = reader.ReadByte();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            u64_0 = reader.ReadUInt64();
            b_2 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
        }
    }
}
