using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitEnv
    {
        public void SteamDecode(BitReader reader)
        {
            subPKTInitEnv5 = reader.Read<subPKTInitEnv5>();
            b = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
            u64 = reader.ReadUInt64();
            s64 = reader.ReadSimpleInt();
            u32_0 = reader.ReadUInt32();
            u32_1 = reader.ReadUInt32();
            blist = reader.ReadList<Byte>();
        }
    }
}
