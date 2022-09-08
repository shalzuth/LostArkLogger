using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitEnv
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            u32_0 = reader.ReadUInt32();
            u16list_0 = reader.ReadList<UInt16>();
            PlayerId = reader.ReadUInt64();
            u32_1 = reader.ReadUInt32();
            subPKTInitEnv8 = reader.Read<subPKTInitEnv8>();
            s64_1 = reader.ReadUInt64();
            s64_0 = reader.ReadSimpleInt();
        }
    }
}
