using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public void SteamDecode(BitReader reader)
        {
            field0 = reader.ReadByte();
            subfield0 = reader.ReadBytes(0);
            OwnerId = reader.ReadUInt64();
            subfield1 = reader.ReadBytes(31);
            npcStruct = reader.Read<NpcStruct>();
        }
    }
}
