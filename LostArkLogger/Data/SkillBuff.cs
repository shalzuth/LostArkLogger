using System;
using System.Collections.Generic;

namespace LostArkLogger
{
    public class SkillBuff
    {
        public static Dictionary<UInt32, String> Items = (Dictionary<UInt32, String>)ObjectSerialize.Deserialize(Properties.Resources.SkillBuff);
        public static String GetSkillBuffName(UInt32 id)
        {
            if (GameMsg.Items.ContainsKey("tip.name.skillbuff_" + id)) return GameMsg.Items["tip.name.skillbuff_" + id];
            if (Items.ContainsKey(id)) return Items[id];
            return "UnknownSkillBuff";
        }
    }
}
