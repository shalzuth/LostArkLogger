using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTTriggerStartNotify
    {
        public PKTTriggerStartNotify(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
        }
        public UInt64 SourceID;
        public UInt32 TriggerSignalType;
        public UInt32 TriggerID;
        public List<UInt64> steps = new List<UInt64>();
        public UInt16 num;
        
    }
}