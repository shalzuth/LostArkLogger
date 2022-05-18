using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewPC
    {
        public PKTNewPC(BitReader reader)
        {
            field0 = reader.ReadByte();
            hasfield1 = reader.ReadByte();
            if (hasfield1 == 1)
                field1 = reader.ReadUInt32();
            hasfield2 = reader.ReadByte();
            if (hasfield2 == 1)
                field2 = new Struct5(reader);
            hasfield3 = reader.ReadByte();
            if (hasfield3 == 1)
                field3 = reader.ReadBytes(20);
            pCStruct = new PCStruct(reader);
            field5 = reader.ReadByte();
            hasfield6 = reader.ReadByte();
            if (hasfield6 == 1)
                field6 = reader.ReadBytes(12);
        }
        public Byte field0; //24
        public Byte hasfield1; //29
        public UInt32 field1; //25
        public Byte hasfield2; //66
        public Struct5 field2; //30
        public Byte hasfield3; //87
        public Byte[] field3; //67
        public PCStruct pCStruct; //88
        public Byte field5; //24408
        public Byte hasfield6; //24421
        public Byte[] field6; //24409
    }
}
