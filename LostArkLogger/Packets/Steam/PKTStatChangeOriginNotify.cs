using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatChangeOriginNotify
    {
        public void SteamDecode(BitReader reader)
        {
            hasfield0 = reader.ReadByte();
            if (hasfield0 == 1)
                field0 = reader.ReadUInt32();
            StatPairChangedList = reader.Read<StatPair>();
            field2 = reader.ReadByte();
            StatPairList = reader.Read<StatPair>();
            ObjectId = reader.ReadUInt64();
        }
    }
}
