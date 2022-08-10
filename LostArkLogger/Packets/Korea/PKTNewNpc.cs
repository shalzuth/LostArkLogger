using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpc
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                u64_0 = reader.ReadUInt64();
            b_3 = reader.ReadByte();
            npcStruct = reader.Read<NpcStruct>();
        }
    }
}
