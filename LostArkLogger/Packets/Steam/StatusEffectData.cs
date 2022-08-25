using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public void SteamDecode(BitReader reader)
        {
            SkillLevel = reader.ReadByte();
            u32_0 = reader.ReadUInt32();
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
            SourceId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                s64_0 = reader.ReadUInt64();
            b_1 = reader.ReadByte();
            s64_1 = reader.ReadSimpleInt();
            bytearraylist_0 = reader.ReadList<Byte[]>(7);
            EffectInstanceId = reader.ReadUInt32();
            StatusEffectId = reader.ReadUInt32();
            InstanceId = reader.ReadUInt64();
        }
    }
}
