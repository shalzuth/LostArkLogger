using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitEnv
    {
        public void SteamDecode(BitReader reader)
        {
            s64_1 = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
            blist_0 = reader.ReadList<Byte>();
            subPKTInitEnv5 = reader.Read<subPKTInitEnv5>();
            s64_0 = reader.ReadSimpleInt();
            u32_0 = reader.ReadUInt32();
            u32_1 = reader.ReadUInt32();
        }
    }
}
