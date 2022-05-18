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
        public Byte field0;
        public Byte[] field1;
        public NpcStruct npcStruct;
    }
}
