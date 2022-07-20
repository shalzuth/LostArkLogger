using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectRemoveNotify
    {
        public void SteamDecode(BitReader reader)
        {
            PartyId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            StatusEffectIds = reader.ReadList<UInt32>();
        }
    }
}
