using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillStageNotify
    {
        public void SteamDecode(BitReader reader)
        {
            SourceId = reader.ReadUInt64();
            field1 = reader.ReadBytes(5);
            SkillId = reader.ReadUInt32();
            field3 = reader.ReadBytes(18);
            Stage = reader.ReadByte();
        }
    }
}
