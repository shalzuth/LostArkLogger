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
                field1 = reader.ReadUInt64();
            npcStruct = reader.Read<NpcStruct>();
            hasfield3 = reader.ReadByte();
            if (hasfield3 == 1)
                field3 = reader.ReadByte();
        }
        public Byte field0;
        public Byte hasfield1;
        public UInt64 field1;
        public NpcStruct npcStruct;
        public Byte hasfield3;
        public Byte field3;
    }
}
