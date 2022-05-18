using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTDeathNotify
    {
        public PKTDeathNotify(BitReader reader)
        {
            hasfield0 = reader.ReadByte();
            if (hasfield0 == 1)
                field0 = reader.ReadByte();
            field1 = reader.ReadUInt32();
            hasfield2 = reader.ReadByte();
            if (hasfield2 == 1)
                field2 = reader.ReadByte();
            field3 = reader.ReadUInt16();
            field4 = reader.ReadUInt64();
            hasfield5 = reader.ReadByte();
            if (hasfield5 == 1)
                field5 = reader.ReadByte();
            field6 = reader.ReadUInt64();
            field7 = reader.ReadUInt64();
            field8 = reader.ReadByte();
        }
        public Byte hasfield0; //25
        public Byte field0; //24
        public UInt32 field1; //28
        public Byte hasfield2; //33
        public Byte field2; //32
        public UInt16 field3; //34
        public UInt64 field4; //40
        public Byte hasfield5; //49
        public Byte field5; //48
        public UInt64 field6; //56
        public UInt64 field7; //64
        public Byte field8; //72
    }
}
