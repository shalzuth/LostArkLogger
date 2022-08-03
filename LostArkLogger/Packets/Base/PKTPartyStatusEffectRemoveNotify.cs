using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectRemoveNotify
    {
        public PKTPartyStatusEffectRemoveNotify(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public List<UInt32> StatusEffectIds;
        public UInt64 PartyId;
        public UInt64 u64_0;
        public Byte b_0;
    }
}
