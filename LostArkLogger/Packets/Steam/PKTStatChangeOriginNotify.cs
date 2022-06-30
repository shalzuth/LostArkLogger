using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatChangeOriginNotify
    {
        public void SteamDecode(BitReader reader)
        {
            ObjectId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                u32 = reader.ReadUInt32();
            StatPairChangedList = reader.Read<StatPair>();
            b_1 = reader.ReadByte();
            StatPairList = reader.Read<StatPair>();
        }
    }
}
