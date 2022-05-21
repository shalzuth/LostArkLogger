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
            StatPairList = reader.Read<StatPair>();
            field2 = reader.ReadByte();
            ObjectId = reader.ReadUInt64();
            StatPairChangedList = reader.Read<StatPair>();
        }
        public Byte hasfield0;
        public UInt32 field0;
        public StatPair StatPairList;
        public Byte field2;
        public UInt64 ObjectId;
        public StatPair StatPairChangedList;
    }
}
