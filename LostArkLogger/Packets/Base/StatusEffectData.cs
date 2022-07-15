using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public StatusEffectData(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public Byte[] Value;
        public UInt64 InstanceId;
        public UInt64 SourceId;
        public UInt32 StatusEffectId;
        public Byte hasValue;
        public UInt64 s64;
        public List<Byte[]> bytearraylist;
        public UInt64 u64;
        public UInt32 StatusEffectInstanceId;
        public UInt32 u32_1;
        public Byte SkillLevel;
        public Byte b_1;
        public Byte b_2;
    }
}
