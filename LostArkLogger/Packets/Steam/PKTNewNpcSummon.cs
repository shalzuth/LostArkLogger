using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public void SteamDecode(BitReader reader)
        {
            bytearray_0 = reader.ReadBytes(18);
            OwnerId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            bytearray_1 = reader.ReadBytes(13);
            npcStruct = reader.Read<NpcStruct>();
        }
    }
}
