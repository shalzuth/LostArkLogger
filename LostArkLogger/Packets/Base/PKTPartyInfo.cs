using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyInfo
    {
        public PKTPartyInfo(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
        }
        public byte b_0;
        public UInt32 PartyInstanceId;
        public UInt32 RaidInstanceId;
        public UInt32 u32_2;
        public List<PartyMemberData> MemberDatas;
        public Byte b_1;
    }

    enum PartyType
    {
        NORMAL = 0,
        RAID = 1,
        CHAOS = 2,
        ARENA = 3,
        COLOSSEUM = 4,
        MOD = 5,
        MATCHING = 6,
    }
    enum PartyLootType
    {
        FREE = 0,
        ROUND_ROBIN = 1,
        LEADER = 2,
        RANDOM = 3,
    }
    enum PartyMemberAuth
    {
        ADMIM = 0,
        LEADER = 1
    }

    enum PartyMemberState
    {
        NORMAL = 0,
        DISCONNECTED = 1,
    }
}
