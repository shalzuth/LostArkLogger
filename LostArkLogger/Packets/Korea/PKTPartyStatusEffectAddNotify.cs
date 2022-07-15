using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectAddNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            PartyId = reader.ReadUInt64();
            b = reader.ReadByte();
            PlayerIdOnRefresh = reader.ReadUInt64();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
        }
    }
}
