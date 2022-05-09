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
        // Tuple<damage value, number of hits, number of crits>
        public Dictionary<String, Tuple<UInt64, UInt32, UInt32>> GetDamages(Func<LogInfo, float> sum, Entity entity = default(Entity))
        {
            var baseSearch = Infos.Where(i => i.SourceEntity.Type == Entity.EntityType.Player);
            IEnumerable<IGrouping<String, LogInfo>> grouped;
            if (entity != default(Entity))
                grouped = baseSearch.Where(i => i.SourceEntity == entity).GroupBy(i => "(" + i.SkillId + ") " + i.SkillName);
            else
                grouped = baseSearch.GroupBy(i => i.SourceEntity.VisibleName);
            return grouped.Select(i => new KeyValuePair<String, Tuple<UInt64, UInt32, UInt32>>(i.Key, Tuple.Create((UInt64)i.Sum(sum), (UInt32)i.Count(), (UInt32)i.Count(log => log.Crit) ))).ToDictionary(x => x.Key, x => x.Value);
            //return grouped.Select(i => new KeyValuePair<String, UInt64>(i.Key, (UInt64)i.Sum(j => (Single)j.Damage))).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
