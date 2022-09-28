using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillStageNotify
    {
        public void SteamDecode(BitReader reader)
        {
            bytearray_1 = reader.ReadBytes(14);
            SkillId = reader.ReadUInt32();
            bytearray_2 = reader.ReadBytes(8);
            SourceId = reader.ReadUInt64();
            bytearray_0 = reader.ReadBytes(17);
            Stage = reader.ReadByte();
            bytearray_3 = reader.ReadBytes(0);
        }
    }
}
