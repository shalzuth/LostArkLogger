using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTDeathNotify
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                b_4 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            b_5 = reader.ReadByte();
            if (b_5 == 1)
                b_6 = reader.ReadByte();
            SourceId = reader.ReadUInt64();
            u32_0 = reader.ReadUInt32();
            TargetId = reader.ReadUInt64();
            u16_0 = reader.ReadUInt16();
        }
    }
}
