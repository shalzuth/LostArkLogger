using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewNpcSummon
    {
        public PKTNewNpcSummon(BitReader reader)
        {
            subfield0 = reader.ReadBytes(30);
            OwnerId = reader.ReadUInt64();
            subfield1 = reader.ReadByte();
            field1 = reader.ReadByte();
            npcStruct = reader.Read<NpcStruct>();
        }
        public Byte[] subfield0;
        public UInt64 OwnerId;
        public Byte subfield1;
        public Byte field1;
        public NpcStruct npcStruct;
    }
}
