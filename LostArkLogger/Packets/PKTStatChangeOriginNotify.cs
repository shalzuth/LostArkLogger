using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTStatChangeOriginNotify
    {
        public PKTStatChangeOriginNotify(BitReader reader)
        {
            StatPairList = new StatPair(reader);
            StatPairChangedList = new StatPair(reader);
            ObjectId = reader.ReadUInt64();
            hasfield3 = reader.ReadByte();
            if (hasfield3 == 1)
                field3 = reader.ReadUInt32();
            field4 = reader.ReadByte();
        }
        public StatPair StatPairList;
        public StatPair StatPairChangedList;
        public UInt64 ObjectId;
        public Byte hasfield3;
        public UInt32 field3;
        public Byte field4;
    }
}
