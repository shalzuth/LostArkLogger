using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTInitEnv
    {
        public PKTInitEnv(BitReader reader)
        {
            field0 = new Struct35(reader);
            PlayerId = reader.ReadUInt64();
            field2 = reader.ReadUInt64();
            field3 = reader.ReadSimpleInt();
            field4 = reader.ReadByte();
            field5 = reader.ReadUInt32();
            field6 = new Struct37(reader);
            field7 = reader.ReadUInt32();
        }
        public Struct35 field0;
        public UInt64 PlayerId;
        public UInt64 field2;
        public UInt64 field3;
        public Byte field4;
        public UInt32 field5;
        public Struct37 field6;
        public UInt32 field7;
    }
}
