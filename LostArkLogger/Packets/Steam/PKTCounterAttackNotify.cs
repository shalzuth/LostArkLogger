using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTCounterAttackNotify
    {
        public void SteamDecode(BitReader reader)
        {
            bytearray_1 = reader.ReadBytes(1);
            TargetId = reader.ReadUInt64();
            bytearray_2 = reader.ReadBytes(0);
            SourceId = reader.ReadUInt64();
            bytearray_0 = reader.ReadBytes(6);
        }
    }
}
