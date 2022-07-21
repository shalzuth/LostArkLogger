using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitEnv
    {
        public void KoreaDecode(BitReader reader)
        {
            u32_0 = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            blist_0 = reader.ReadList<Byte>();
            s64_0 = reader.ReadSimpleInt();
            PlayerId = reader.ReadUInt64();
            s64_1 = reader.ReadUInt64();
            u32_1 = reader.ReadUInt32();
            subPKTInitEnv5 = reader.Read<subPKTInitEnv5>();
        }
    }
}
