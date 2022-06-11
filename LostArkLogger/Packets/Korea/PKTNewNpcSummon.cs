using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public void KoreaDecode(BitReader reader)
        {
            npcStruct = reader.Read<NpcStruct>();
            bytearray_1 = reader.ReadBytes(0);
            OwnerId = reader.ReadUInt64();
            bytearray_0 = reader.ReadBytes(31);
            b = reader.ReadByte();
        }
    }
}
