using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitEnv
    {
        public void SteamDecode(BitReader reader)
        {
            s64_1 = reader.ReadUInt64();
            subPKTInitEnv5 = reader.Read<subPKTInitEnv5>();
            PlayerId = reader.ReadUInt64();
            blist_0 = reader.ReadList<Byte>();
            u32_0 = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            s64_0 = reader.ReadSimpleInt();
            u32_1 = reader.ReadUInt32();
        }
    }
}
