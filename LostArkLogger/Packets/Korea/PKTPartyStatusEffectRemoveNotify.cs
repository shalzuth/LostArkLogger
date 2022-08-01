using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectRemoveNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            StatusEffectIds = reader.ReadList<UInt32>();
            PartyId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
        }
    }
}
