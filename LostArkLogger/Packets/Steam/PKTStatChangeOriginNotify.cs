using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatChangeOriginNotify
    {
        public void SteamDecode(BitReader reader)
        {
            ObjectId = reader.ReadUInt64();
            StatPairChangedList = reader.Read<StatPair>();
            StatPairList = reader.Read<StatPair>();
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                u32 = reader.ReadUInt32();
        }
    }
}
