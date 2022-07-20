using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTInitPC29
    {
        public void SteamDecode(BitReader reader)
        {
            u16 = reader.ReadUInt16();
            p64_0 = reader.ReadPackedInt();
            p64_1 = reader.ReadPackedInt();
            u64 = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
        }
    }
}
