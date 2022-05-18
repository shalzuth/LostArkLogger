using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class SkillDamageMoveEvent
    {
        public SkillDamageMoveEvent(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                skillDamageMoveEvents.Add(new SkillDamageMoveEvents(reader));
            }
        }
        public UInt16 num; //0
        public List<SkillDamageMoveEvents> skillDamageMoveEvents = new List<SkillDamageMoveEvents>(); //0
    }
}
