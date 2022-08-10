using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTInitPC29
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            p64_0 = reader.ReadPackedInt();
            p64_1 = reader.ReadPackedInt();
            u16_0 = reader.ReadUInt16();
            u64_0 = reader.ReadUInt64();
        }
    }
}
