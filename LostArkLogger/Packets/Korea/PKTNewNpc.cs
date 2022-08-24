using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpc
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            npcStruct = reader.Read<NpcStruct>();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                u64_0 = reader.ReadUInt64();
        }
    }
}
