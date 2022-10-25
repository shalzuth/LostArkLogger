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
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                u64_0 = reader.ReadUInt64();
            statusEffectData = reader.Read<StatusEffectData>();
            u64_1 = reader.ReadUInt64();
        }
    }
}
