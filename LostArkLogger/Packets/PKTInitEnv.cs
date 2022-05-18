using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTInitEnv
    {
        public PKTInitEnv(BitReader reader)
        {
            field0 = reader.ReadUInt32();
            field1 = reader.ReadUInt64();
            field2 = reader.ReadSimpleInt();
            field3 = reader.ReadUInt32();
            field4 = new Struct35(reader);
            field5 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
            field7 = new Struct36(reader);
        }
        public UInt32 field0;
        public UInt64 field1;
        public UInt64 field2;
        public UInt32 field3;
        public Struct35 field4;
        public Byte field5;
        public UInt64 PlayerId;
        public Struct36 field7;
    }
}
