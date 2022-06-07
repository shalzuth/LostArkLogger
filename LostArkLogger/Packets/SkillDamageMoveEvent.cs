using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageMoveEvent
    {
        public SkillDamageMoveEvent(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public UInt16 field0;
        public UInt64 field1;
        public UInt16 field2;
        public UInt64 field3;
        public SkillDamageEvent skillDamageEvent;
        public UInt64 field5;
        public UInt64 field6;
        public Byte field7;
        public UInt16 field8;
    }
}
