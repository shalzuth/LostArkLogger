using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillStartNotify
    {
        public PKTSkillStartNotify(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) SteamDecode(reader);
        }
        public UInt64 field0;
        public Byte hasfield1;
        public UInt32 field1;
        public UInt16 field2;
        public Byte field3;
        public UInt16 field4;
        public Byte hasfield5;
        public UInt16 field5;
        public UInt64 field6;
        public List<Object> field7;
        public UInt64 SourceId;
        public Byte hasfield9;
        public UInt32 field9;
        public UInt64 field10;
        public UInt32 SkillId;
    }
}
