using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class SkillDamageEvents
    {
        public SkillDamageEvents(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                skillDamageEvents.Add(new SkillDamageEvent(reader));
            }
        }
        public UInt16 num;
        public List<SkillDamageEvent> skillDamageEvents = new List<SkillDamageEvent>();
    }
}
