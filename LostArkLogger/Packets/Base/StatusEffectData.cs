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
        public UInt32 EffectInstanceId;
        public UInt32 StatusEffectId;
        public Byte hasValue;
        public Byte SkillLevel;
        public UInt64 s64;
        public List<Byte[]> bytearraylist;
        public UInt64 u64;
        public UInt32 u32;
        public Byte b_0;
        public Byte b_1;
    }
}
