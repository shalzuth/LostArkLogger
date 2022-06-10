using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public void SteamDecode(BitReader reader)
        {
            b = reader.ReadByte();
            field0 = reader.ReadBytes(4071);
            OwnerId = reader.ReadUInt64();
            field2 = reader.ReadBytes(56);
            npcStruct = reader.Read<NpcStruct>();
        }
    }
}
