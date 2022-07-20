using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatusEffectAddNotify
    {
        public void SteamDecode(BitReader reader)
        {
            u64_0 = reader.ReadUInt64();
            New = reader.ReadByte();
            ObjectId = reader.ReadUInt64();
            statusEffectData = reader.Read<StatusEffectData>();
        }
    }
}
