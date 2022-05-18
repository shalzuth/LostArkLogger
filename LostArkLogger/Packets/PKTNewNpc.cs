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
            hasfield2 = reader.ReadByte();
            if (hasfield2 == 1)
                field2 = reader.ReadByte();
            npc = new NpcStruct(reader);
        }
        public Byte field0; //24
        public Byte hasfield1; //33
        public UInt64 field1; //25
        public Byte hasfield2; //35
        public Byte field2; //34
        public NpcStruct npc; //40
    }
}
