using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpc
    {
        public void SteamDecode(BitReader reader)
        {
            field0 = reader.ReadByte();
            hasfield1 = reader.ReadByte();
            if (hasfield1 == 1)
                field1 = reader.ReadByte();
            hasfield2 = reader.ReadByte();
            if (hasfield2 == 1)
                field2 = reader.ReadUInt64();
            npcStruct = reader.Read<NpcStruct>();
        }
    }
}
