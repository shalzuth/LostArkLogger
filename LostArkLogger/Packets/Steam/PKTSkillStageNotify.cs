using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillStageNotify
    {
        public void SteamDecode(BitReader reader)
        {
            bytearray_0 = reader.ReadBytes(20);
            Stage = reader.ReadByte();
            bytearray_2 = reader.ReadBytes(4);
            SourceId = reader.ReadUInt64();
            bytearray_3 = reader.ReadBytes(1);
            SkillId = reader.ReadUInt32();
            bytearray_1 = reader.ReadBytes(16);
        }
    }
}
