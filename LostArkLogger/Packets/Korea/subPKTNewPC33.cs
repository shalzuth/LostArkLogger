using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewPC33
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                bytearray_0 = reader.ReadBytes(12);
            bytearray_1 = reader.ReadBytes(12);
            u32_0 = reader.ReadUInt32();
            u32_1 = reader.ReadUInt32();
        }
    }
}
