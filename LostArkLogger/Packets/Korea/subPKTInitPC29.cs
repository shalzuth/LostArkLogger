using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTInitPC29
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            u16_0 = reader.ReadUInt16();
            p64_0 = reader.ReadPackedInt();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            p64_1 = reader.ReadPackedInt();
        }
    }
}
