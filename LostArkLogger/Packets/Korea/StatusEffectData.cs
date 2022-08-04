using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public void KoreaDecode(BitReader reader)
        {
            EffectInstanceId = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            u32_0 = reader.ReadUInt32();
            s64_0 = reader.ReadSimpleInt();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                s64_1 = reader.ReadUInt64();
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
            StatusEffectId = reader.ReadUInt32();
            bytearraylist_0 = reader.ReadList<Byte[]>(7);
            InstanceId = reader.ReadUInt64();
            SkillLevel = reader.ReadByte();
        }
    }
}
