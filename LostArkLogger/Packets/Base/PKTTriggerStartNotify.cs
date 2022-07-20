using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTTriggerStartNotify
    {
        public PKTTriggerStartNotify(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public UInt64 TriggerUnitIndex;
        public UInt32 ActorId;
        public UInt32 Signal;
        public List<UInt64> u64list_0;
    }
}
