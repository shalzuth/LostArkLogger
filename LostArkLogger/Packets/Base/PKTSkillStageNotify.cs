using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillStageNotify
    {
        public PKTSkillStageNotify(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public UInt64 SourceId;
        public UInt32 SkillId;
        public Byte Stage;
        public Byte[] bytearray_0;
        public Byte[] bytearray_1;
        public Byte[] bytearray_2;
        public Byte[] bytearray_3;
    }
}
