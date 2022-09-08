using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatChangeOriginNotify
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                u32_0 = reader.ReadUInt32();
            ObjectId = reader.ReadUInt64();
            StatPairList = reader.Read<StatPair>();
            StatPairChangedList = reader.Read<StatPair>();
        }
    }
}
