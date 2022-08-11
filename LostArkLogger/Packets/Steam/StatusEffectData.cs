using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public void SteamDecode(BitReader reader)
        {
            SourceId = reader.ReadSimpleInt();
            bytearraylist_0 = reader.ReadList<Byte[]>(7);
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
            EffectInstanceId = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                u64_0 = reader.ReadUInt64();
            u32_0 = reader.ReadUInt32();
            StatusEffectId = reader.ReadUInt32();
            u64_1 = reader.ReadUInt64();
            InstanceId = reader.ReadUInt64();
            SkillLevel = reader.ReadByte();
        }
    }
}
