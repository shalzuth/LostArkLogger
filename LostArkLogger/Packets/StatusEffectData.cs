using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public StatusEffectData(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) SteamDecode(reader);
        }
        public UInt32 field0;
        public Byte field1;
        public Byte field2;
        public Byte hasValue;
        public Byte[] Value;
        public UInt64 InstanceId;
        public UInt32 BuffId;
        public List<Byte[]> field6;
        public UInt32 field7;
        public UInt64 field8;
        public Byte hasfield9;
        public UInt64 field9;
        public UInt64 SourceId;
    }
}
