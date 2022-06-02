using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewNpc
    {
        public PKTNewNpc(BitReader reader)
        {
            field0 = reader.ReadByte();
            hasfield1 = reader.ReadByte();
            if (hasfield1 == 1)
                field1 = reader.ReadByte();
            hasfield2 = reader.ReadByte();
            if (hasfield2 == 1)
                field2 = reader.ReadUInt64();
            npcStruct = reader.Read<NpcStruct>();
        }
        public Byte field0;
        public Byte hasfield1;
        public Byte field1;
        public Byte hasfield2;
        public UInt64 field2;
        public NpcStruct npcStruct;
    }
}
