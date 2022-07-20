using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectRemoveNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            StatusEffectIds = reader.ReadList<UInt32>();
            b_0 = reader.ReadByte();
            PartyId = reader.ReadUInt64();
        }
    }
}
