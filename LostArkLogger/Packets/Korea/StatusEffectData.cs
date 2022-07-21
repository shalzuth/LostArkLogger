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
            StatusEffectId = reader.ReadUInt32();
            bytearraylist_0 = reader.ReadList<Byte[]>(7);
            SkillLevel = reader.ReadByte();
            SourceId = reader.ReadUInt64();
            s64_0 = reader.ReadSimpleInt();
            EffectInstanceId = reader.ReadUInt32();
            u32_0 = reader.ReadUInt32();
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                s64_1 = reader.ReadUInt64();
        }
    }
}
