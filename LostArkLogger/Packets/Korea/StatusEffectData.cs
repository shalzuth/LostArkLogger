using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            InstanceId = reader.ReadUInt64();
            SourceId = reader.ReadSimpleInt();
            StatusEffectId = reader.ReadUInt32();
            SkillLevel = reader.ReadByte();
            u32_0 = reader.ReadUInt32();
            u64_0 = reader.ReadUInt64();
            EffectInstanceId = reader.ReadUInt32();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                u64_1 = reader.ReadUInt64();
            bytearraylist_0 = reader.ReadList<Byte[]>(7);
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
        }
    }
}
