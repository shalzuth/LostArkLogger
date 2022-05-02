using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public class SkillEffect
    {
        public static Dictionary<String, String> Items = (Dictionary<String, String>)ObjectSerialize.Deserialize(Properties.Resources.SkillEffect);
    }
}
