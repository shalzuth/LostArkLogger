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
            statusEffectData = reader.Read<StatusEffectData>();
            u64_0 = reader.ReadUInt64();
        }
    }
}
