using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public class GameMsg_English
    {
        public static Dictionary<String, String> Items = (Dictionary<String, String>)ObjectSerialize.Deserialize(Properties.Resources.GameMsg_English);
    }
}
