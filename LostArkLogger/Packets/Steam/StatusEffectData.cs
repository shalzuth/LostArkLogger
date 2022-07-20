using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public void SteamDecode(BitReader reader)
        {
            bytearraylist = reader.ReadList<Byte[]>(7);
            SkillLevel = reader.ReadByte();
            EffectInstanceId = reader.ReadUInt32();
            u32 = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                u64 = reader.ReadUInt64();
            StatusEffectId = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
            b_1 = reader.ReadByte();
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
            InstanceId = reader.ReadUInt64();
            s64 = reader.ReadSimpleInt();
        }
    }
}
