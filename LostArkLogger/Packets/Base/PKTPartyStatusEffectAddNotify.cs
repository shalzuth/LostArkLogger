using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectAddNotify
    {
        public PKTPartyStatusEffectAddNotify(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public UInt64 PartyId;
        public UInt64 PlayerIdOnRefresh;
        public List<StatusEffectData> statusEffectDatas;
        public UInt64 u64_0;
        public Byte b_0;
    }
}
