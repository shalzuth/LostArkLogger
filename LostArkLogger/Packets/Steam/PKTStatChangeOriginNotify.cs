using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatChangeOriginNotify
    {
        public void SteamDecode(BitReader reader)
        {
            StatPairList = reader.Read<StatPair>();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                u32_0 = reader.ReadUInt32();
            b_1 = reader.ReadByte();
            ObjectId = reader.ReadUInt64();
            StatPairChangedList = reader.Read<StatPair>();
        }
    }
}
