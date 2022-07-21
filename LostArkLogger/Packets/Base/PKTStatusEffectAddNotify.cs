using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatusEffectAddNotify
    {
        public PKTStatusEffectAddNotify(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public UInt64 ObjectId;
        public Byte New;
        public StatusEffectData statusEffectData;
        public UInt64 u64_0;
        public UInt64 u64_1;
        public Byte b_0;
    }
}
