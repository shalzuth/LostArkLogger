using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PartyMemberData
    {
        public void SteamDecode(BitReader reader)
        {
            RosterLevel = reader.ReadUInt16();
            PartyMemberNumber = reader.ReadByte();
            b_1 = reader.ReadByte();
            CurHP = reader.ReadPackedInt();
            u32_0 = reader.ReadUInt32();
            b_2 = reader.ReadByte();
            u64_1 = reader.ReadUInt64();
            u32_1 = reader.ReadUInt32();
            b_3 = reader.ReadByte();
            CharacterId = reader.ReadUInt64();
            b_4 = reader.ReadByte();
            CharacterLevel = reader.ReadUInt16();
            MaxHP = reader.ReadPackedInt();
            u16_3 = reader.ReadUInt16();
            b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            Name = reader.ReadString();
            u32_2 = reader.ReadUInt32();
            u64_4 = reader.ReadUInt64();
            b_7 = reader.ReadByte();
        }
    }
}
