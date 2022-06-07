using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewPC_1
    {
        public void SteamDecode(BitReader reader)
        {
            field0 = reader.ReadUInt32();
            field1 = reader.ReadBytes(12);
            field2 = reader.ReadUInt32();
            hasfield3 = reader.ReadByte();
            if (hasfield3 == 1)
                field3 = reader.ReadBytes(12);
        }
    }
}
