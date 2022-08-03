using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpc
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                u64_0 = reader.ReadUInt64();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            npcStruct = reader.Read<NpcStruct>();
        }
    }
}
