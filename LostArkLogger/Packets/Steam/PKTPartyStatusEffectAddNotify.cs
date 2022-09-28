using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectAddNotify
    {
        public void SteamDecode(BitReader reader)
        {
            PartyId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            PlayerIdOnRefresh = reader.ReadUInt64();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
        }
    }
}
