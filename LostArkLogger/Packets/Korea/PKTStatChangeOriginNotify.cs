using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatChangeOriginNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            StatPairChangedList = reader.Read<StatPair>();
            StatPairList = reader.Read<StatPair>();
            b_0 = reader.ReadByte();
            ObjectId = reader.ReadUInt64();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                u32_0 = reader.ReadUInt32();
        }
    }
}
