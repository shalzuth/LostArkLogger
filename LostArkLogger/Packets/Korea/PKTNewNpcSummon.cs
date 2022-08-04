using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public void KoreaDecode(BitReader reader)
        {
            bytearray_1 = reader.ReadBytes(13);
            OwnerId = reader.ReadUInt64();
            bytearray_0 = reader.ReadBytes(18);
            b_0 = reader.ReadByte();
            npcStruct = reader.Read<NpcStruct>();
        }
    }
}
