using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTDeathNotify
    {
        public void SteamDecode(BitReader reader)
        {
            u32_0 = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            u64_0 = reader.ReadUInt64();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            if (b_5 == 1)
                b_6 = reader.ReadByte();
            TargetId = reader.ReadUInt64();
        }
    }
}
