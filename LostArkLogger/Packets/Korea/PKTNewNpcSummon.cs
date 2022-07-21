using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            bytearray_1 = reader.ReadBytes(6);
            OwnerId = reader.ReadUInt64();
            bytearray_0 = reader.ReadBytes(25);
            npcStruct = reader.Read<NpcStruct>();
        }
    }
}
