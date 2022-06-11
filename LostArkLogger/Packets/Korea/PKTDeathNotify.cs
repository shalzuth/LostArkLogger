using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTDeathNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            u64 = reader.ReadUInt64();
            u32 = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
            SourceId = reader.ReadUInt64();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                b_3 = reader.ReadByte();
            b_4 = reader.ReadByte();
            if (b_4 == 1)
                b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            u16 = reader.ReadUInt16();
            TargetId = reader.ReadUInt64();
        }
    }
}
