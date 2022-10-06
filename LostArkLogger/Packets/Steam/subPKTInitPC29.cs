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
            u16_0 = reader.ReadUInt16();
            u64_0 = reader.ReadUInt64();
            p64_0 = reader.ReadPackedInt();
            b_2 = reader.ReadByte();
            p64_1 = reader.ReadPackedInt();
        }
    }
}
