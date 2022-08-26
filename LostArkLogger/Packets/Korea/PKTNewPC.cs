using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewPC
    {
        public void KoreaDecode(BitReader reader)
        {
            pCStruct = reader.Read<PCStruct>();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                subPKTNewPC33 = reader.Read<subPKTNewPC33>();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                bytearray_0 = reader.ReadBytes(20);
            b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                bytearray_1 = reader.ReadBytes(12);
            b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            if (b_5 == 1)
                u32_0 = reader.ReadUInt32();
        }
    }
}
