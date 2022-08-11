using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public void KoreaDecode(BitReader reader)
        {
            bytearray_0 = reader.ReadBytes(20);
            OwnerId = reader.ReadUInt64();
            bytearray_1 = reader.ReadBytes(11);
            npcStruct = reader.Read<NpcStruct>();
            b_0 = reader.ReadByte();
        }
    }
}
