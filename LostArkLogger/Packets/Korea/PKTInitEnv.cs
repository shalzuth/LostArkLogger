using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitEnv
    {
        public void KoreaDecode(BitReader reader)
        {
            s64_0 = reader.ReadSimpleInt();
            u32_0 = reader.ReadUInt32();
            s64_1 = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            u32_1 = reader.ReadUInt32();
            subPKTInitEnv8 = reader.Read<subPKTInitEnv8>();
            PlayerId = reader.ReadUInt64();
            u16list_0 = reader.ReadList<UInt16>();
        }
    }
}
