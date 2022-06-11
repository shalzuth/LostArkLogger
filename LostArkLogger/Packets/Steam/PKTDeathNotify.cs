using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTDeathNotify
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            u32 = reader.ReadUInt32();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                b_4 = reader.ReadByte();
            u16 = reader.ReadUInt16();
            b_5 = reader.ReadByte();
            if (b_5 == 1)
                b_6 = reader.ReadByte();
            SourceId = reader.ReadUInt64();
            u64 = reader.ReadUInt64();
            TargetId = reader.ReadUInt64();
        }
    }
}
