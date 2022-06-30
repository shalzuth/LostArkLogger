using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public void SteamDecode(BitReader reader)
        {
            b = reader.ReadByte();
            bytearray_0 = reader.ReadBytes(23);
            OwnerId = reader.ReadUInt64();
            bytearray_1 = reader.ReadBytes(8);
            npcStruct = reader.Read<NpcStruct>();
        }
    }
}
