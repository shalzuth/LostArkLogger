using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatusEffectAddNotify
    {
        public void SteamDecode(BitReader reader)
        {
            New = reader.ReadByte();
            statusEffectData = reader.Read<StatusEffectData>();
            ObjectId = reader.ReadUInt64();
            u64_0 = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                u64_1 = reader.ReadUInt64();
        }
    }
}
