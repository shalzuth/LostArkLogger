using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTStatusEffectAddNotify
    {
        public PKTStatusEffectAddNotify(BitReader reader)
        {
            field0 = reader.ReadUInt64();
            statusEffectData = reader.Read<StatusEffectData>();
            New = reader.ReadByte();
            ObjectId = reader.ReadUInt64();
        }
        public UInt64 field0;
        public StatusEffectData statusEffectData;
        public Byte New;
        public UInt64 ObjectId;
    }
}
