using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpc_1_4_1
    {
        public void SteamDecode(BitReader reader)
        {
            field0 = reader.ReadUInt16();
            field1 = reader.ReadPackedInt();
            field2 = reader.ReadUInt64();
            field3 = reader.ReadByte();
            field4 = reader.ReadPackedInt();
            field5 = reader.ReadByte();
            field6 = reader.ReadByte();
        }
    }
}
