using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitEnv
    {
        public void KoreaDecode(BitReader reader)
        {
            u64 = reader.ReadUInt64();
            s64 = reader.ReadSimpleInt();
            subPKTInitEnv5 = reader.Read<subPKTInitEnv5>();
            u32_0 = reader.ReadUInt32();
            b = reader.ReadByte();
            blist = reader.ReadList<Byte>();
            u32_1 = reader.ReadUInt32();
            PlayerId = reader.ReadUInt64();
        }
    }
}
