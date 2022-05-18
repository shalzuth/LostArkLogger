using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTStatusEffectAddNotify
    {
        public PKTStatusEffectAddNotify(BitReader reader)
        {
            New = reader.ReadByte();
            ObjectId = reader.ReadUInt64();
            field2 = reader.ReadUInt64();
            statusEffectData = new StatusEffectData(reader);
        }
        public Byte New;
        public UInt64 ObjectId;
        public UInt64 field2;
        public StatusEffectData statusEffectData;
    }
}
