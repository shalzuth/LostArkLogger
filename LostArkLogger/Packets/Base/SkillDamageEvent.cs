using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public SkillDamageEvent(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
        }
        public Int64 CurrentHealth;
        public Int64 Damage;
        public Int64 MaxHealth;
        public UInt64 TargetId;
        public Byte Modifier;
        public UInt16 u16;
        public Byte b_0;
        public Byte b_1;
        public Byte b_2;
    }
}
