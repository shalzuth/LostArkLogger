using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public class Skill
    {
        public static Dictionary<Int32, String[]> Items = (Dictionary<Int32, String[]>)ObjectSerialize.Deserialize(Properties.Resources.Skill);
        public static String GetSkillName(UInt32 id, UInt32 subId)
        {
            if (id == 0 && subId == 0) return "Bleed"; // ?? someone fix this
            var skillName = "";
            if (Items.ContainsKey((int)id))
            {
                var skill = Items[(int)id];
                if (skill[0].Length > 0)
                {
                    if (GameMsg_English.Items.ContainsKey(skill[0])) skillName = GameMsg_English.Items[skill[0]];
                }
                if (skillName.Length == 0) skillName = skill[1];
            }
            if (id == 0)
            {
                var temp = GetSkillName(subId / 10, subId);
                skillName = temp;
            }
            if (skillName.Length == 0 && SkillEffect.Items.ContainsKey(subId.ToString())) skillName += SkillEffect.Items[subId.ToString()];
            return skillName;
        }
        public static String GetClassFromSkill(UInt32 id)
        {
            if (Items.ContainsKey((int)id))
            {
                var skill = Items[(int)id];
                return Npc.GetPcClass(uint.Parse(skill[2]));
            }
            return "UnknownClass";
        }
    }
}
