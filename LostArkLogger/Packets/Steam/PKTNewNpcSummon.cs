using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            npcStruct = reader.Read<NpcStruct>();
            bytearray_1 = reader.ReadBytes(0);
            OwnerId = reader.ReadUInt64();
            bytearray_0 = reader.ReadBytes(31);
        }
    }
}
