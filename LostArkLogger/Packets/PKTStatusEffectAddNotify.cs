using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatusEffectAddNotify
    {
        public PKTStatusEffectAddNotify(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public UInt64 field0;
        public StatusEffectData statusEffectData;
        public Byte New;
        public UInt64 ObjectId;
    }
}
