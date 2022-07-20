using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitEnv
    {
        public void KoreaDecode(BitReader reader)
        {
            s64_0 = reader.ReadSimpleInt();
            subPKTInitEnv5 = reader.Read<subPKTInitEnv5>();
            u32_0 = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            blist_0 = reader.ReadList<Byte>();
            u32_1 = reader.ReadUInt32();
            PlayerId = reader.ReadUInt64();
        }
    }
}
