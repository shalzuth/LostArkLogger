using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class SkillDamageMoveEvents
    {
        public SkillDamageMoveEvents(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                skillDamageMoveEvents.Add(new SkillDamageMoveEvent(reader));
            }
        }
        public UInt16 num;
        public List<SkillDamageMoveEvent> skillDamageMoveEvents = new List<SkillDamageMoveEvent>();
    }
}
