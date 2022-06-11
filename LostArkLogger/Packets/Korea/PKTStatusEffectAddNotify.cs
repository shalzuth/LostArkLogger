using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatusEffectAddNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            u64 = reader.ReadUInt64();
            New = reader.ReadByte();
            statusEffectData = reader.Read<StatusEffectData>();
            ObjectId = reader.ReadUInt64();
        }
    }
}
