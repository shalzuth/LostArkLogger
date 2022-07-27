using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectRemoveNotify
    {
        public void SteamDecode(BitReader reader)
        {
            StatusEffectIds = reader.ReadList<UInt32>();
            PartyId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
        }
    }
}
