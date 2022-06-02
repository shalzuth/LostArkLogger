using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewNpcSummon
    {
        public PKTNewNpcSummon(BitReader reader)
        {
            field0 = reader.ReadByte();
            subfield0 = reader.ReadBytes(0);
            OwnerId = reader.ReadUInt64();
            subfield1 = reader.ReadBytes(31);
            npcStruct = reader.Read<NpcStruct>();
        }
        public Byte field0;
        public Byte[] subfield0;
        public UInt64 OwnerId;
        public Byte[] subfield1;
        public NpcStruct npcStruct;
    }
}
