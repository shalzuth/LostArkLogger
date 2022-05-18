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
                skillDamageEvent.Add(new SkillDamageEvent(reader));
            }
        }
        public UInt16 num; //0
        public List<SkillDamageEvent> skillDamageEvent = new List<SkillDamageEvent>(); //2
    }
}
