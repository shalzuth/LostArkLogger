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
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            PlayerIdOnRefresh = reader.ReadUInt64();
        }
    }
}
