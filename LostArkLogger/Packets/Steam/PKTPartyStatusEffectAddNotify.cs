using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectAddNotify
    {
        public void SteamDecode(BitReader reader)
        {
            PlayerIdOnRefresh = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            PartyId = reader.ReadUInt64();
        }
    }
}
