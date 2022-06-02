using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTInitEnv
    {
        public PKTInitEnv(BitReader reader)
        {
            pKTInitEnv_1 = reader.Read<PKTInitEnv_1>();
            field1 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
            field3 = reader.ReadUInt64();
            field4 = reader.ReadSimpleInt();
            field5 = reader.ReadUInt32();
            field6 = reader.ReadUInt32();
            field7 = reader.ReadList<Byte>();
        }
        public PKTInitEnv_1 pKTInitEnv_1;
        public Byte field1;
        public UInt64 PlayerId;
        public UInt64 field3;
        public UInt64 field4;
        public UInt32 field5;
        public UInt32 field6;
        public List<Byte> field7;
    }
}
