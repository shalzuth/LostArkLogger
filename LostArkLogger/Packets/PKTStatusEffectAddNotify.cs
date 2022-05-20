using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTStatusEffectAddNotify
    {
        public PKTStatusEffectAddNotify(BitReader reader)
        {
            statusEffectData = reader.Read<StatusEffectData>();
            ObjectId = reader.ReadUInt64();
            field2 = reader.ReadUInt64();
            New = reader.ReadByte();
        }
        public StatusEffectData statusEffectData;
        public UInt64 ObjectId;
        public UInt64 field2;
        public Byte New;
    }
}
