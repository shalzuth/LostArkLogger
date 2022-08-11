using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectAddNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            u64_0 = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            PartyId = reader.ReadUInt64();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            PlayerIdOnRefresh = reader.ReadUInt64();
        }
    }
}
