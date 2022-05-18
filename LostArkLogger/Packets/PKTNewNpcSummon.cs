using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewNpcSummon
    {
        public PKTNewNpcSummon(BitReader reader)
        {
            field0 = reader.ReadByte();
            subfield0 = reader.ReadBytes(27);
            OwnerId = reader.ReadUInt64();
            subfield1 = reader.ReadUInt32();
            npcStruct = new NpcStruct(reader);
        }
        public Byte field0;
        public Byte[] subfield0;
        public UInt64 OwnerId;
        public UInt32 subfield1;
        public NpcStruct npcStruct;
    }
}
