using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public void SteamDecode(BitReader reader)
        {
            bytearray_0 = reader.ReadBytes(49);
            OwnerId = reader.ReadUInt64();
            bytearray_1 = reader.ReadBytes(4078);
            npcStruct = reader.Read<NpcStruct>();
            b_0 = reader.ReadByte();
        }
    }
}
