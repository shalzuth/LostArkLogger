using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public void KoreaDecode(BitReader reader)
        {
            EffectInstanceId = reader.ReadUInt32();
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
            SourceId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            u32_0 = reader.ReadUInt32();
            StatusEffectId = reader.ReadUInt32();
            InstanceId = reader.ReadUInt64();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                s64_1 = reader.ReadUInt64();
            s64_0 = reader.ReadSimpleInt();
            SkillLevel = reader.ReadByte();
            bytearraylist_0 = reader.ReadList<Byte[]>(7);
        }
    }
}
