using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTDeathNotify
    {
        public void SteamDecode(BitReader reader)
        {
            u16 = reader.ReadUInt16();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                b_3 = reader.ReadByte();
            u64 = reader.ReadUInt64();
            SourceId = reader.ReadUInt64();
            b_4 = reader.ReadByte();
            u32 = reader.ReadUInt32();
            TargetId = reader.ReadUInt64();
            b_5 = reader.ReadByte();
            if (b_5 == 1)
                b_6 = reader.ReadByte();
        }
    }
}
