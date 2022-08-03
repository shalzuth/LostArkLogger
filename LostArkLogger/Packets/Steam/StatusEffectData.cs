using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public void SteamDecode(BitReader reader)
        {
            SourceId = reader.ReadUInt64();
            bytearraylist_0 = reader.ReadList<Byte[]>(7);
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                s64_1 = reader.ReadUInt64();
            b_1 = reader.ReadByte();
            EffectInstanceId = reader.ReadUInt32();
            u32_0 = reader.ReadUInt32();
            InstanceId = reader.ReadUInt64();
            SkillLevel = reader.ReadByte();
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
            s64_0 = reader.ReadSimpleInt();
            StatusEffectId = reader.ReadUInt32();
        }
    }
}
