using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public void SteamDecode(BitReader reader)
        {
            StatusEffectInstanceId = reader.ReadUInt32(); // some ID
            InstanceId = reader.ReadUInt64(); // of the instance you are in or?
            SourceId = reader.ReadUInt64();
            bytearraylist = reader.ReadList<Byte[]>(7);
            SkillLevel = reader.ReadByte();
            u32_1 = reader.ReadUInt32();
            b_1 = reader.ReadByte();
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
            s64 = reader.ReadSimpleInt();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                u64 = reader.ReadUInt64();
            StatusEffectId = reader.ReadUInt32();
        }
    }
}
