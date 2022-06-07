using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillDamageMoveEvent
    {
        public void SteamDecode(BitReader reader)
        {
            field0 = reader.ReadUInt16();
            field1 = reader.ReadUInt64();
            field2 = reader.ReadUInt16();
            field3 = reader.ReadUInt64();
            skillDamageEvent = reader.Read<SkillDamageEvent>();
            field5 = reader.ReadFlag();
            field6 = reader.ReadUInt64();
            field7 = reader.ReadByte();
            field8 = reader.ReadUInt16();
        }
    }
}
