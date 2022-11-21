using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectRemoveNotify
    {
        public void SteamDecode(BitReader reader)
        {
            StatusEffectIds = reader.ReadList<UInt32>();
            b_0 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            PartyId = reader.ReadUInt64();
        }
    }
}
