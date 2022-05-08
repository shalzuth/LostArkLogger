using System;
using System.Collections.Generic;

namespace LostArkLogger
{
    public class AuctionItem
    {
        static Dictionary<UInt32, string> statList = new Dictionary<UInt32, string>()
        {
            [15] = "Crit",
            [16] = "Spec",
            [17] = "Domination",
            [18] = "Swiftness",
            [19] = "Endurance",
            [20] = "Expertise"
        };

        public static string getStatName(UInt32 statId)
        {
            if (statList.ContainsKey(statId)) return statList[statId];
            return "Unknown Stat " + statId.ToString();
        }

        static Dictionary<UInt32, string> engravingList = new Dictionary<UInt32, string>()
        {
            [107] = "Disrespect",
            [109] = "Spirit Absorption",
            [110] = "Ether Predator",
            [111] = "Stabilized Status",
            [118] = "Grudge",
            [121] = "Super Charge",
            [123] = "Strong Will",
            [125] = "Mayhem",
            [127] = "Esoteric Skill Enhancement",
            [129] = "Enhanced Weapon",
            [130] = "Firepower Enhancement",
            [134] = "Drops of Ether",
            [140] = "Crisis Evasion",
            [141] = "Keen Blunt Weapon",
            [142] = "Vital Point Hit",
            [167] = "Max MP Increase",
            [168] = "MP Efficiency Increase",
            [188] = "Berserker's Technique",
            [189] = "First Intention",
            [190] = "Ultimate Skill: Taijutsu",
            [191] = "Shock Training",
            [192] = "Pistoleer",
            [193] = "Barrage Enhancement",
            [194] = "True Courage",
            [195] = "Desperate Salvation",
            [202] = "Master of Escape",
            [224] = "Combat Readiness",
            [225] = "Lone Knight",
            [235] = "Fortitude",
            [236] = "Crushing Fist",
            [237] = "Shield Piercing",
            [238] = "Master's Tenacity",
            [239] = "Divine Protection",
            [240] = "Heavy Armor",
            [241] = "Explosive Expert",
            [242] = "Enhanced Shield",
            [243] = "Necromancy",
            [244] = "Preemptive Strike",
            [245] = "Broken Bone",
            [246] = "Lightning Fury",
            [247] = "Cursed Doll",
            [248] = "Contender",
            [249] = "Ambush Master",
            [251] = "Magick Stream",
            [253] = "Barricade",
            [254] = "Raid Captain",
            [255] = "Awakening",
            [256] = "Energy Overflow",
            [257] = "Robust Spirit",
            [258] = "Loyal Companion",
            [259] = "Death Strike",
            [276] = "Pinnacle",
            [277] = "Control",
            [278] = "Remaining Energy",
            [279] = "Surge",
            [280] = "Perfect Suppression",
            [281] = "Demonic Impulse",
            [282] = "Judgment",
            [283] = "Blessed Aura",
            [288] = "Master Brawler",
            [289] = "Peacemaker",
            [290] = "Time to Hunt",
            [291] = "Deathblow",
            [292] = "Esoteric Flurry",
            [293] = "Igniter",
            [294] = "Reflux",
            [295] = "Increases Mass",
            [296] = "Propulsion",
            [297] = "Hit Master",
            [298] = "Sight Focus",
            [299] = "Adrenaline",
            [300] = "All-Out Attack",
            [301] = "Expert",
            [302] = "Emergency Rescue",
            [303] = "Precise Dagger",
            [803] = "Move Speed Reduction",
            [802] = "Atk. Speed Reduction",
            [801] = "Defense Reduction",
            [800] = "Atk. Power Reduction"
        };

        public static string getEngravingName(UInt32 engravingId)
        {
            if (engravingList.ContainsKey(engravingId)) return engravingList[engravingId];
            return "Unknown Engraving " + engravingId.ToString();
        }
    }
}
