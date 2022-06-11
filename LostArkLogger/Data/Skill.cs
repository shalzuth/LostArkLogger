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
                    if (GameMsg.Items.ContainsKey(skill[0])) skillName = GameMsg.Items[skill[0]];
                }
                if (skillName.Length == 0) skillName = skill[1];
            }
            if (id == 0)
            {
                var temp = GetSkillName(subId / 10, subId);
                skillName = temp;
            }
            if (skillName.Length == 0 && SkillEffect.Items.ContainsKey((int)subId)) skillName += SkillEffect.Items[(int)subId];
            return skillName;
        }
        public static String GetSkillName(UInt32 id)
        {
            if (id == 0) return "Bleed"; // ?? someone fix this
            var skillName = "UnknownSkill";
            if (Items.ContainsKey((int)id))
            {
                var skill = Items[(int)id];
                if (skill[0].Length > 0)
                {
                    if (GameMsg.Items.ContainsKey(skill[0])) skillName = GameMsg.Items[skill[0]];
                }
                if (skillName == "UnknownSkill") skillName = skill[1];
            }
            return skillName;
        }
        public static String GetSkillEffectName(UInt32 id)
        {
            if (SkillEffect.Items.ContainsKey((int)id)) return SkillEffect.Items[(int)id];
            return "UnknownSkillEffect";
        }
        public static Boolean GetSkillIcon(UInt32 id, out String iconFile, out Int32 iconIndex)
        {
            iconFile = "";
            iconIndex = -1;
            if (Items.ContainsKey((int)id))
            {
                var skill = Items[(int)id];
                iconFile = skill[3].Replace("_0", "_");
                iconIndex = int.Parse(skill[4]);
                if (!String.IsNullOrEmpty(iconFile) && iconIndex != -1) return true;
            }
            return false;
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
