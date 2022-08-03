using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatusEffectAddNotify
    {
        public void SteamDecode(BitReader reader)
        {
            u64_0 = reader.ReadUInt64();
            ObjectId = reader.ReadUInt64();
            statusEffectData = reader.Read<StatusEffectData>();
            New = reader.ReadByte();
        }
    }
}
