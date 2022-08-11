using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillStartNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            packed_0 = reader.ReadPackedValues(1, 1, 4, 4, 4, 3, 6);
            u64_0 = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            SkillId = reader.ReadUInt32();
            u16_0 = reader.ReadUInt16();
            SourceId = reader.ReadUInt64();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                u32_0 = reader.ReadUInt32();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                u16_1 = reader.ReadUInt16();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                u32_1 = reader.ReadUInt32();
            u16_2 = reader.ReadUInt16();
            u64_1 = reader.ReadUInt64();
            u64_2 = reader.ReadUInt64();
        }
    }
}
