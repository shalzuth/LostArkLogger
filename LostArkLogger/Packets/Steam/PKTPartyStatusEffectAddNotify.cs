using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectAddNotify
    {
        public void SteamDecode(BitReader reader)
        {
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            b_0 = reader.ReadByte();
            PartyId = reader.ReadUInt64();
            PlayerIdOnRefresh = reader.ReadUInt64();
        }
    }
}
