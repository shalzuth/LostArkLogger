using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatusEffectAddNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            u64_0 = reader.ReadUInt64();
            New = reader.ReadByte();
            if (New == 1)
                u64_1 = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            ObjectId = reader.ReadUInt64();
            statusEffectData = reader.Read<StatusEffectData>();
        }
    }
}
