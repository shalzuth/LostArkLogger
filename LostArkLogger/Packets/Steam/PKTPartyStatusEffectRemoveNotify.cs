using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectRemoveNotify
    {
        public void SteamDecode(BitReader reader)
        {
            PartyId = reader.ReadUInt64();
            StatusEffectIds = reader.ReadList<UInt32>();
            b_0 = reader.ReadByte();
        }
    }
}
