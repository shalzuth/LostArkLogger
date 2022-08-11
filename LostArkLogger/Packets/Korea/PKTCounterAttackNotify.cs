using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTCounterAttackNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            bytearray_1 = reader.ReadBytes(0);
            TargetId = reader.ReadUInt64();
            bytearray_2 = reader.ReadBytes(4093);
            SourceId = reader.ReadUInt64();
            bytearray_0 = reader.ReadBytes(10);
        }
    }
}
