using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatChangeOriginNotify
    {
        public void SteamDecode(BitReader reader)
        {
            ObjectId = reader.ReadUInt64();
            StatPairList = reader.Read<StatPair>();
            b_1 = reader.ReadByte();
            StatPairChangedList = reader.Read<StatPair>();
            var b_2 = reader.ReadByte();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                u32_0 = reader.ReadUInt32();
            var b_3 = reader.ReadByte();
        }
    }
}
