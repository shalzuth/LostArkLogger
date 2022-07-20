using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageMoveEvent
    {
        public SkillDamageMoveEvent(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public SkillDamageEvent skillDamageEvent;
        public UInt64 flag_0;
        public UInt64 flag_1;
        public UInt64 flag_2;
        public UInt64 flag_3;
        public UInt16 u16_0;
        public UInt16 u16_1;
        public UInt16 u16_2;
        public Byte b_0;
    }
}
