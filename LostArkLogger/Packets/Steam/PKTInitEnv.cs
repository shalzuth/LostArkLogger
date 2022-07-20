using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitEnv
    {
        public void SteamDecode(BitReader reader)
        {
            u64 = reader.ReadUInt64();
            subPKTInitEnv5 = reader.Read<subPKTInitEnv5>();
            PlayerId = reader.ReadUInt64();
            blist = reader.ReadList<Byte>();
            u32_0 = reader.ReadUInt32();
            b = reader.ReadByte();
            s64 = reader.ReadSimpleInt();
            u32_1 = reader.ReadUInt32();
        }
    }
}
