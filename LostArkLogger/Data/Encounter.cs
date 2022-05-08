using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace LostArkLogger
{
    public class Encounter
    {
        public DateTime Start = DateTime.Now;
        public DateTime End;
        public ConcurrentDictionary<UInt64, Entity> Entities = new ConcurrentDictionary<UInt64, Entity>();
        public ConcurrentBag<LogInfo> Infos = new ConcurrentBag<LogInfo>();
        public String EncounterName
        {
            get
            {
                return (Infos.Count == 0 ? "Current" : Infos.GroupBy(i => i.DestinationEntity.VisibleName).Select(i => new KeyValuePair<String, UInt64>(i.Key, (UInt64)i.Sum(j => (Single)j.Damage))).OrderByDescending(i => i.Value).FirstOrDefault().Key) + " : " + Start;
            }
        }
        public Dictionary<String, UInt64> TopLevelDamage
        {
            get
            {
                return Infos.GroupBy(i => i.SourceEntity.VisibleName).Select(i => new KeyValuePair<String, UInt64>(i.Key, (UInt64)i.Sum(j => (Single)j.Damage))).ToDictionary(x => x.Key, x => x.Value);
            }
        }
        public Dictionary<String, UInt64> Counterattacks
        {
            get
            {
                return Infos.Where(i=>i.Counter).GroupBy(i => i.SourceEntity.VisibleName).Select(i => new KeyValuePair<String, UInt64>(i.Key, (UInt64)i.Sum(j => j.Counter ? 1 : 0))).ToDictionary(x => x.Key, x => x.Value);
            }
        }
        public Dictionary<String, UInt64> Stagger
        {
            get
            {
                return Infos.Where(i=>i.Stagger>0).GroupBy(i => i.SourceEntity.VisibleName).Select(i => new KeyValuePair<String, UInt64>(i.Key, (UInt64)i.Sum(j => (Single)j.Stagger))).ToDictionary(x => x.Key, x => x.Value);
            }
        }
        public Dictionary<String, UInt64> GetSkillDamages(Entity entity)
        {
            return Infos.Where(i=>i.SourceEntity == entity).GroupBy(i => "(" + i.SkillId + ") " + i.SkillName).Select(i => new KeyValuePair<String, UInt64>(i.Key, (UInt64)i.Sum(j => (Single)j.Damage))).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
