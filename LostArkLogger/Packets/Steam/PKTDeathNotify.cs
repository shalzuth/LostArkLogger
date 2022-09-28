using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTDeathNotify
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                b_3 = reader.ReadByte();
            b_4 = reader.ReadByte();
            SourceId = reader.ReadUInt64();
            u64_0 = reader.ReadUInt64();
            TargetId = reader.ReadUInt64();
            b_5 = reader.ReadByte();
            if (b_5 == 1)
                b_6 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            u32_0 = reader.ReadUInt32();
        }
    }
}
