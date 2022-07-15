using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public void KoreaDecode(BitReader reader)
        {
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                SourceId = reader.ReadUInt64();
            b_1 = reader.ReadByte();
            s64 = reader.ReadSimpleInt();
            EffectInstanceId = reader.ReadUInt32();
            InstanceId = reader.ReadUInt64();
            u64 = reader.ReadUInt64();
            SkillLevel = reader.ReadByte();
            bytearraylist = reader.ReadList<Byte[]>(7);
            StatusEffectId = reader.ReadUInt32();
            u32 = reader.ReadUInt32();
        }
    }
}
