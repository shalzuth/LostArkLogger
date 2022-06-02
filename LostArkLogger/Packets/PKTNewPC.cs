using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewPC
    {
        public PKTNewPC(BitReader reader)
        {
            hasfield0 = reader.ReadByte();
            if (hasfield0 == 1)
                field0 = reader.ReadBytes(12);
            hasfield1 = reader.ReadByte();
            if (hasfield1 == 1)
                field1 = reader.ReadUInt32();
            hasfield2 = reader.ReadByte();
            if (hasfield2 == 1)
                pKTNewPC_1 = reader.Read<PKTNewPC_1>();
            field3 = reader.ReadByte();
            hasfield4 = reader.ReadByte();
            if (hasfield4 == 1)
                field4 = reader.ReadBytes(20);
            pCStruct = reader.Read<PCStruct>();
            field6 = reader.ReadByte();
        }
        public Byte hasfield0;
        public Byte[] field0;
        public Byte hasfield1;
        public UInt32 field1;
        public Byte hasfield2;
        public PKTNewPC_1 pKTNewPC_1;
        public Byte field3;
        public Byte hasfield4;
        public Byte[] field4;
        public PCStruct pCStruct;
        public Byte field6;
    }
}
