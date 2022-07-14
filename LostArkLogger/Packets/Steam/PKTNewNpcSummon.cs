using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public void SteamDecode(BitReader reader)
        {
            b = reader.ReadByte();
            bytearray_1 = reader.ReadBytes(11);
            OwnerId = reader.ReadUInt64();
            bytearray_0 = reader.ReadBytes(20);
            npcStruct = reader.Read<NpcStruct>();
        }
    }
}
