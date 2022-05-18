using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTStatChangeOriginNotify
    {
        public PKTStatChangeOriginNotify(BitReader reader)
        {
            field0 = new Struct20(reader);
            field1 = new Struct20(reader);
            field2 = reader.ReadUInt64();
            hasfield3 = reader.ReadByte();
            if (hasfield3 == 1)
                field3 = reader.ReadUInt32();
            field4 = reader.ReadByte();
        }
        public Struct20 field0; //64
        public Struct20 field1; //64
        public UInt64 field2; //7328
        public Byte hasfield3; //7340
        public UInt32 field3; //7336
        public Byte field4; //7341
    }
}
