using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTDeathNotify
    {
        public PKTDeathNotify(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) SteamDecode(reader);
        }
        public Byte field0;
        public UInt32 field1;
        public Byte hasfield2;
        public Byte field2;
        public Byte hasfield3;
        public Byte field3;
        public UInt16 field4;
        public Byte hasfield5;
        public Byte field5;
        public UInt64 SourceId;
        public UInt64 field7;
        public UInt64 TargetId;
    }
}
