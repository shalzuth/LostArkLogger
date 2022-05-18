using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewNpcSummon
    {
        public PKTNewNpcSummon(BitReader reader)
        {
            field0 = reader.ReadByte();
            field1 = reader.ReadBytes(39);
            npcStruct = new NpcStruct(reader);
        }
        public Byte field0; //24
        public Byte[] field1; //25
        public NpcStruct npcStruct; //64
    }
}
