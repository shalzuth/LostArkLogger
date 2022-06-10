using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatChangeOriginNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            ObjectId = reader.ReadUInt64();
            StatPairList = reader.Read<StatPair>();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                u32 = reader.ReadUInt32();
            StatPairChangedList = reader.Read<StatPair>();
        }
    }
}
