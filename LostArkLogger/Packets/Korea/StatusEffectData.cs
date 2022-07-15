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
            b_2 = reader.ReadByte();
            if (b_2 == 1)
               u64  = reader.ReadUInt64();
            b_1 = reader.ReadByte();
            s64 = reader.ReadSimpleInt();
            u32_1 = reader.ReadUInt32();
            InstanceId = reader.ReadUInt64();
            SourceId = reader.ReadUInt64();
            SkillLevel = reader.ReadByte(); // this might not be the right byte
            bytearraylist = reader.ReadList<Byte[]>(7);
            StatusEffectId = reader.ReadUInt32();
            StatusEffectInstanceId = reader.ReadUInt32();
        }
    }
}
