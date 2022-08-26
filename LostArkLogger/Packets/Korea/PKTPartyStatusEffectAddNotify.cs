using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectAddNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            b_0 = reader.ReadByte();
            PartyId = reader.ReadUInt64();
            u64_0 = reader.ReadUInt64();
            PlayerIdOnRefresh = reader.ReadUInt64();
        }
    }
}
