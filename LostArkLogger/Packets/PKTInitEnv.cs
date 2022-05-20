using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTInitEnv
    {
        public PKTInitEnv(BitReader reader)
        {
            pKTInitEnv_1 = reader.Read<PKTInitEnv_1>();
            PlayerId = reader.ReadUInt64();
            field2 = reader.ReadUInt64();
            field3 = reader.ReadSimpleInt();
            field4 = reader.ReadByte();
            field5 = reader.ReadUInt32();
            field6 = reader.ReadList<Byte>();
            field7 = reader.ReadUInt32();
        }
        public PKTInitEnv_1 pKTInitEnv_1;
        public UInt64 PlayerId;
        public UInt64 field2;
        public UInt64 field3;
        public Byte field4;
        public UInt32 field5;
        public List<Byte> field6;
        public UInt32 field7;
    }
}
