using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageEvent
    {
        public SkillDamageEvent(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) SteamDecode(reader);
        }
        public Byte hasfield0;
        public Byte field0;
        public UInt64 TargetId;
        public Int64 Damage;
        public UInt16 field3;
        public Int64 MaxHealth;
        public Int64 CurrentHealth;
        public Byte field6;
        public Byte Modifier;
    }
}
