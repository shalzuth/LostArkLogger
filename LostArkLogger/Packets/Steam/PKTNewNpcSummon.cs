using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public void SteamDecode(BitReader reader)
        {
            npcStruct = reader.Read<NpcStruct>();
            bytearray_1 = reader.ReadBytes(6);
            OwnerId = reader.ReadUInt64();
            bytearray_0 = reader.ReadBytes(25);
            b = reader.ReadByte();
        }
    }
}
