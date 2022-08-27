using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatusEffectAddNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            New = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                u64_1 = reader.ReadUInt64();
            ObjectId = reader.ReadUInt64();
            statusEffectData = reader.Read<StatusEffectData>();
        }
    }
}
