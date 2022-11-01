using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpc
    {
        public void SteamDecode(BitReader reader)
        {
            npcStruct = reader.Read<NpcStruct>();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                u64_0 = reader.ReadUInt64();
        }
    }
}
