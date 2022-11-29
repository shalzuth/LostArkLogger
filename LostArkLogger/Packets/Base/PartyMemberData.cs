using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PartyMemberData
    {
        public PartyMemberData(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
        }

        public UInt16 RosterLevel;
        public byte PartyMemberNumber; // this is 0 based 0-3
        public byte b_1;
        public Int64 CurHP; //packedInt
        public UInt32 u32_0;
        public byte b_2;
        public UInt64 u64_1;
        public UInt32 u32_1;
        public byte b_3;
        public UInt64 CharacterId;
        public byte b_4;
        public UInt16 CharacterLevel;
        public Int64 MaxHP; //packedInt
        public UInt16 u16_3;
        public byte b_5;
        public byte b_6;
        public string Name;
        public UInt32 u32_2;
        public UInt64 u64_4;
        public byte b_7;
    }
}
