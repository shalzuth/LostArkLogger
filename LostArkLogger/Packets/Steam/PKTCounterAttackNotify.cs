using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTCounterAttackNotify
    {
        public void SteamDecode(BitReader reader)
        {
            bytearray_0 = reader.ReadBytes(4);
            TargetId = reader.ReadUInt64();
            bytearray_1 = reader.ReadBytes(1);
            SourceId = reader.ReadUInt64();
            bytearray_2 = reader.ReadBytes(0);
        }
    }
}
