using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillStageNotify
    {
        public void SteamDecode(BitReader reader)
        {
            field0 = reader.ReadBytes(17);
            SourceId = reader.ReadUInt64();
            field2 = reader.ReadBytes(5);
            SkillId = reader.ReadUInt32();
            field4 = reader.ReadBytes(18);
            Stage = reader.ReadByte();
            field6 = reader.ReadBytes(0);
        }
    }
}
