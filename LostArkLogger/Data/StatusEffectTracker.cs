using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    internal class StatusEffectTracker
    {
        private readonly ConcurrentDictionary<UInt64, ConcurrentDictionary<UInt64, StatusEffect>> BuffMap;
        public Parser parser;
        public event Action? OnChange;
        public event Action<StatusEffect, TimeSpan, DateTime>? OnStatusEffectEnded;
        public StatusEffectTracker(Parser p)
        {
            BuffMap = new ConcurrentDictionary<UInt64, ConcurrentDictionary<UInt64, StatusEffect>>();
            parser = p;
            parser.onNewZone += OnNewZone;
        }

        public void OnNewZone()
        {
            BuffMap.Clear();
        }

        public void Process(PKTStatusEffectAddNotify effect)
        {
            var buffList = GetBuffList(effect.ObjectId);//get by targetId
            Entity sourceEntity = parser.GetSourceEntity(effect.statusEffectData.SourceId);
            var buff = new StatusEffect { Started = DateTime.UtcNow , StatusEffectId = effect.statusEffectData.StatusEffectId, InstanceId = effect.statusEffectData.StatusEffectInstanceId, SourceId = sourceEntity.EntityId, TargetId = effect.ObjectId, Type = StatusEffect.StatusEffectType.Local };
            if (buffList.ContainsKey(buff.InstanceId)) {
                // end this buf now, it got refreshed
                buffList.Remove(buff.InstanceId, out var oldBuff);
                var calcNow = DateTime.UtcNow;
                var duration = (calcNow - oldBuff.Started);
                OnStatusEffectEnded?.Invoke(oldBuff, duration, calcNow);
            }
            buffList.TryAdd(buff.InstanceId, buff);
            if (!parser.currentEncounter.Entities.ContainsKey(effect.ObjectId))//search targetId
            {
                Console.WriteLine("Could not find Entity with ID " + BitConverter.ToString(BitConverter.GetBytes(effect.ObjectId)) + " for adding statuseffect");//log targetId
            }
            Console.WriteLine("Buff Added " + buff.ToString());
            OnChange?.Invoke();
        }

        public void Process(PKTPartyStatusEffectAddNotify effect)
        {
            foreach (var statusEffect in effect.Unk0.Unk0_0_0)
            {
                var applierId = statusEffect.SourceId;
                if (effect.PlayerIdOnRefresh != 0x0)
                    applierId = effect.PlayerIdOnRefresh;
                Entity sourceEntity = parser.GetSourceEntity(applierId);
                var buffList = GetBuffList(applierId);
                var buff = new StatusEffect { Started = DateTime.UtcNow, StatusEffectId = statusEffect.StatusEffectId , InstanceId = statusEffect.EffectInstanceId, SourceId = sourceEntity.EntityId, TargetId = effect.PartyId, Type = StatusEffect.StatusEffectType.Party };
                if (buffList.ContainsKey(buff.InstanceId))
                {
                    // this buff was refreshed
                    buffList.Remove(buff.InstanceId, out StatusEffect oldBuff);
                    var calcNow = DateTime.UtcNow;
                    var duration = (calcNow - oldBuff.Started);
                    OnStatusEffectEnded?.Invoke(oldBuff, duration, calcNow);
                }
                buffList.TryAdd(buff.InstanceId, buff);
                if (!parser.currentEncounter.PartyEntities.ContainsKey(effect.PartyId))
                {
                    Console.WriteLine("Could not find Party Entity with ID " + BitConverter.ToString(BitConverter.GetBytes(effect.PartyId)) + " for adding statuseffect");
                }
                Console.WriteLine("Party Buff Added " + buff.ToString());
            }
            OnChange?.Invoke();
        }

        public void Process(PKTPartyStatusEffectRemoveNotify effect)
        {
            var buffList = GetBuffList(effect.PartyId);
            foreach (var effectInstanceId in effect.StatusEffectIds)
            {
                if (buffList.ContainsKey(effectInstanceId.InstanceId))
                {
                    var oldBuff = buffList[effectInstanceId.InstanceId];
                    var calcNow = DateTime.UtcNow;
                    var duration = (calcNow - oldBuff.Started);
                    OnStatusEffectEnded?.Invoke(oldBuff, duration, calcNow);
                }
                if (buffList.TryRemove(effectInstanceId.InstanceId, out _))
                {
                    Console.WriteLine("Party Buff removed " + effectInstanceId.InstanceId.ToString());
                }
                else
                {
                    Console.WriteLine("Party Buff NOT removed " + effectInstanceId.InstanceId.ToString());
                }
            }
            OnChange?.Invoke();
        }

        public void Process(PKTStatusEffectRemoveNotify effect)
        {
            var buffList = GetBuffList(effect.PlayerId);
            foreach (var effectInstanceId in effect.StatusEffectIds)
            {
                if (buffList.ContainsKey(effectInstanceId.InstanceId))
                {
                    var oldBuff = buffList[effectInstanceId.InstanceId];
                    var calcNow = DateTime.UtcNow;
                    var duration = (calcNow - oldBuff.Started);
                    OnStatusEffectEnded?.Invoke(oldBuff, duration, calcNow);
                }
                if (buffList.TryRemove(effectInstanceId.InstanceId, out _))
                {
                    Console.WriteLine("Buff removed " + effectInstanceId.ToString());
                }
                else
                {
                    Console.WriteLine("Buff NOT removed " + effectInstanceId.ToString());
                }
            }
            OnChange?.Invoke();
        }

        public void Process(PKTDeathNotify paket)
        {
            Console.Write("Death Notifyed");
            ConcurrentDictionary<UInt64, StatusEffect> buffList;
            if(BuffMap.TryRemove(paket.TargetId, out buffList))
            {
                foreach (var buff in buffList)
                {
                    var oldBuff = buff.Value;
                    var calcNow = DateTime.UtcNow;
                    var duration = (calcNow - oldBuff.Started);
                    OnStatusEffectEnded?.Invoke(oldBuff, duration, calcNow);
                }
            }
            OnChange?.Invoke();
        }

        public int GetBuffCountFor(UInt64 PlayerId)
        {
            return GetBuffList(PlayerId).Count;
        }

        public ConcurrentDictionary<UInt64, ConcurrentDictionary<UInt64, StatusEffect>> GetBuffMap()
        {
            return BuffMap;
        }

        private ConcurrentDictionary<UInt64, StatusEffect> GetBuffList(UInt64 targetId)
        {
            if (!BuffMap.TryGetValue(targetId, out ConcurrentDictionary<UInt64, StatusEffect> buffList))
            {
                buffList = new ConcurrentDictionary<UInt64, StatusEffect>();
                BuffMap.TryAdd(targetId, buffList);
            }
            return buffList;
        }

    }
}
