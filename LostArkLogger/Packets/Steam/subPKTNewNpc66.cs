using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc66
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            itemInfos = reader.ReadList<ItemInfo>();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            str_0 = reader.ReadString();
            u16_0 = reader.ReadUInt16();
        }
    }
}
