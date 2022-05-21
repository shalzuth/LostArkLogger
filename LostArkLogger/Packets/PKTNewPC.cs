using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewPC
    {
        public PKTNewPC(BitReader reader)
        {
            field0 = reader.ReadByte();
            pCStruct = reader.Read<PCStruct>();
            field2 = reader.ReadByte();
            hasfield3 = reader.ReadByte();
            if (hasfield3 == 1)
                field3 = reader.ReadUInt32();
            hasfield4 = reader.ReadByte();
            if (hasfield4 == 1)
                field4 = reader.ReadBytes(12);
            hasfield5 = reader.ReadByte();
            if (hasfield5 == 1)
                field5 = reader.ReadBytes(20);
            hasfield6 = reader.ReadByte();
            if (hasfield6 == 1)
                pKTNewPC_2 = reader.Read<PKTNewPC_2>();
        }
        public Byte field0;
        public PCStruct pCStruct;
        public Byte field2;
        public Byte hasfield3;
        public UInt32 field3;
        public Byte hasfield4;
        public Byte[] field4;
        public Byte hasfield5;
        public Byte[] field5;
        public Byte hasfield6;
        public PKTNewPC_2 pKTNewPC_2;
    }
}
