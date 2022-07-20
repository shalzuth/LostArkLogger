using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTPartyStatusEffectAddNotify
    {
        public void SteamDecode(BitReader reader)
        {
            b = reader.ReadByte();
            PartyId = reader.ReadUInt64();
            PlayerIdOnRefresh = reader.ReadUInt64();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
        }
    }
}
