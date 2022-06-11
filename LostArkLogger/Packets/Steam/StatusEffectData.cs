using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public void SteamDecode(BitReader reader)
        {
            u32_0 = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
            InstanceId = reader.ReadUInt64();
            BuffId = reader.ReadUInt32();
            bytearraylist = reader.ReadList<Byte[]>(7);
            u32_1 = reader.ReadUInt32();
            s64 = reader.ReadSimpleInt();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                u64 = reader.ReadUInt64();
            SourceId = reader.ReadUInt64();
        }
    }
}
