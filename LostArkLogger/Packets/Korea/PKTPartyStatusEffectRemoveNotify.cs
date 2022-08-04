using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectRemoveNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            PartyId = reader.ReadUInt64();
            u64_0 = reader.ReadUInt64();
            StatusEffectIds = reader.ReadList<UInt32>();
            b_0 = reader.ReadByte();
        }
    }
}
