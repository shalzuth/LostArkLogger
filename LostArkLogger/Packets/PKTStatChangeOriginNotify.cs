using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTStatChangeOriginNotify
    {
        public PKTStatChangeOriginNotify(BitReader reader)
        {
            hasfield0 = reader.ReadByte();
            if (hasfield0 == 1)
                field0 = reader.ReadUInt32();
            StatPairChangedList = reader.Read<StatPair>();
            field2 = reader.ReadByte();
            StatPairList = reader.Read<StatPair>();
            ObjectId = reader.ReadUInt64();
        }
        public Byte hasfield0;
        public UInt32 field0;
        public StatPair StatPairChangedList;
        public Byte field2;
        public StatPair StatPairList;
        public UInt64 ObjectId;
    }
}
