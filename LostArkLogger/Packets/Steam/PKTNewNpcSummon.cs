using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public void SteamDecode(BitReader reader)
        {
            npcStruct = reader.Read<NpcStruct>();
            bytearray_1 = reader.ReadBytes(7);
            OwnerId = reader.ReadUInt64();
            bytearray_0 = reader.ReadBytes(24);
            b_0 = reader.ReadByte();
        }
    }
}
