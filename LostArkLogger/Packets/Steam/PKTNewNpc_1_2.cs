using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpc_1_2
    {
        public void SteamDecode(BitReader reader)
        {
            field0 = reader.ReadByte();
            field1 = reader.ReadUInt16();
            field2 = reader.ReadString();
            field3 = reader.ReadByte();
            field4 = reader.ReadUInt64();
            field5 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            pKTNewNpc_1_2_2 = reader.Read<PKTNewNpc_1_2_2>();
        }
    }
}
