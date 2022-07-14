using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillStageNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            bytearray_1 = reader.ReadBytes(9);
            SkillId = reader.ReadUInt32();
            bytearray_0 = reader.ReadBytes(4);
            SourceId = reader.ReadUInt64();
            bytearray_1 = reader.ReadBytes(4);
            Stage = reader.ReadByte();
            bytearray_0 = reader.ReadBytes(22);
        }
    }
}
