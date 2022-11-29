using System;

namespace LostArkLogger
{
    public partial class PKTPartyUnknown
    {
        public PKTPartyUnknown(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
        }
        public UInt64 CharacterId;
        public byte[] ba_0;
        public UInt32 PartyInstanceId;
        public UInt32 u32_0;
        public UInt32 RaidInstanceId;
        public byte b_0;
        public UInt16 u16_0;
        public byte b_1;
        public UInt64 u64_0;
        public byte[] ba_1;
    }
}
