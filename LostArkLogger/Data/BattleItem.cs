using System.Collections.Generic;

namespace LostArkLogger
{
    public class BattleItem
    {
       public static Dictionary<uint, string> Projectiles = new Dictionary<uint, string>()
       {
           {33200, "Pheromone Bomb"  },
           {32000, "Flash Grenade"   },  {32004, "Splendid Flash Grenade"},
           {32010, "Flame Grenade"   },  {32016, "Splendid Flame Grenade"},
           {32020, "Frost Grenade"   },  {23025, "Splendid Frost Grenade"},
           {32030, "Electric Grenade"},  {32035, "Splendid Lightening Grenade"},
           {32240, "Dark Grenade"    },  {32244, "Splendid Dark Grenade" },
           {32260, "Corrosive Bomb"  },  {32262, "Splendid Corrosive Bomb"},
           {32310, "Whirlwind Grenade"}, {32313, "Splendid Whirlwind Greande"},
           {32320, "Clay Grenade"     }, {32325, "Splendid Clay Grenade"},
           {32350, "Sleep Bomb" },       {32352, "Splendid Sleep Bomb"},
           {32360, "Sacred Bomb" },      {32363, "Splendid Sleep Bomb"},
           {32140, "Destruction Bomb" }, {32142, "Splendid Destruction Bomb"}
       };
       public static Dictionary<uint, string> Buffs = new Dictionary<uint, string>()
       {
           {32380, "Atropine Potion" },
           {32100, "Marching Flag" },    {32102, "Splendid Marching Flag"},
           {32270, "Protective Potion"}, {32271, "Splendid Protective Potion"},
           {32300, "Sprinter's Robe" },  {32301, "Splendid Sprinter's Robe" },
           {33500, "Time Stop Potion" },
           {32402, "Thunder Potion" },   {32403, "Splendid Thunder Potion"}
       };

        public static bool IsBattleItem(uint id, string type)
        {
            if (type == "projectile") return Projectiles.ContainsKey(id);
            if (type == "buff") return Buffs.ContainsKey(id);
            else return false;
        }

        public static string GetBattleItemName(uint id)
        {
            if (Projectiles.ContainsKey(id))
                return Projectiles[id];
            else 
                return Buffs[id];
        }
    }
}
