using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageMoveEvent
    {
        public SkillDamageMoveEvent(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
        }
        public SkillDamageEvent skillDamageEvent;
        public UInt64 flag;
        public UInt64 u64_0;
        public UInt64 u64_1;
        public UInt64 u64_2;
        public UInt16 u16_0;
        public UInt16 u16_1;
        public UInt16 u16_2;
        public Byte b;
    }
}
