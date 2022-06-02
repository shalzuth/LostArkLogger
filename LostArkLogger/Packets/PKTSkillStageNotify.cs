using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTSkillStageNotify
    {
        public PKTSkillStageNotify(BitReader reader)
        {
            SourceId = reader.ReadUInt64();
            field1 = reader.ReadBytes(5);
            SkillId = reader.ReadUInt32();
            field3 = reader.ReadBytes(18);
            Stage = reader.ReadByte();
        }
        public UInt64 SourceId;
        public Byte[] field1;
        public UInt32 SkillId;
        public Byte[] field3;
        public Byte Stage;
    }
}
