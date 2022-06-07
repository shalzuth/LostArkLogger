using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewPC
    {
        public void SteamDecode(BitReader reader)
        {
            hasfield0 = reader.ReadByte();
            if (hasfield0 == 1)
                field0 = reader.ReadBytes(12);
            hasfield1 = reader.ReadByte();
            if (hasfield1 == 1)
                field1 = reader.ReadUInt32();
            hasfield2 = reader.ReadByte();
            if (hasfield2 == 1)
                pKTNewPC_1 = reader.Read<PKTNewPC_1>();
            field3 = reader.ReadByte();
            hasfield4 = reader.ReadByte();
            if (hasfield4 == 1)
                field4 = reader.ReadBytes(20);
            pCStruct = reader.Read<PCStruct>();
            field6 = reader.ReadByte();
        }
    }
}
