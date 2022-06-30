using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatusEffectAddNotify
    {
        public void SteamDecode(BitReader reader)
        {
            ObjectId = reader.ReadUInt64();
            New = reader.ReadByte();
            u64 = reader.ReadUInt64();
            statusEffectData = reader.Read<StatusEffectData>();
        }
    }
}
