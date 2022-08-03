using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillStageNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            bytearray_0 = reader.ReadBytes(33);
            SourceId = reader.ReadUInt64();
            bytearray_2 = reader.ReadBytes(2);
            SkillId = reader.ReadUInt32();
            bytearray_3 = reader.ReadBytes(0);
            Stage = reader.ReadByte();
            bytearray_1 = reader.ReadBytes(4);
        }
    }
}
