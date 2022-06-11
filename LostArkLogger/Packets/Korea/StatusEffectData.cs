using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public void KoreaDecode(BitReader reader)
        {
            InstanceId = reader.ReadUInt64();
            s64 = reader.ReadSimpleInt();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                SourceId = reader.ReadUInt64();
            u32_0 = reader.ReadUInt32();
            bytearraylist = reader.ReadList<Byte[]>(7);
            u64 = reader.ReadUInt64();
            BuffId = reader.ReadUInt32();
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
            u32_1 = reader.ReadUInt32();
            b_2 = reader.ReadByte();
            b_0 = reader.ReadByte();
        }
    }
}
