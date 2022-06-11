using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitEnv
    {
        public void KoreaDecode(BitReader reader)
        {
            subPKTInitEnv5 = reader.Read<subPKTInitEnv5>();
            PlayerId = reader.ReadUInt64();
            s64 = reader.ReadSimpleInt();
            b = reader.ReadByte();
            u32_0 = reader.ReadUInt32();
            blist = reader.ReadList<Byte>();
            u64 = reader.ReadUInt64();
            u32_1 = reader.ReadUInt32();
        }
    }
}
