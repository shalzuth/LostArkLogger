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

        public void Process(PKTInitPC packet)
        {
            var buffList = GetBuffList(packet.PlayerId);
            foreach (var statusEffect in packet.statusEffectDatas)
            {
                ProcessStatusEffectData(statusEffect, packet.PlayerId, statusEffect.SourceId, buffList, StatusEffect.StatusEffectType.Local);
            }
            OnChange?.Invoke();
        }

        public void Process(PKTNewNpc packet)
        {
            var buffList = GetBuffList(packet.npcStruct.NpcId);
            foreach (var statusEffect in packet.npcStruct.statusEffectDatas)
            {
                ProcessStatusEffectData(statusEffect, packet.npcStruct.NpcId, statusEffect.SourceId, buffList, StatusEffect.StatusEffectType.Local);
            }
            OnChange?.Invoke();
        }

        public void Process(PKTNewPC packet)
        {
            var buffList = GetBuffList(packet.pCStruct.PartyId);
            foreach (var statusEffect in packet.pCStruct.statusEffectDatas)
            {
                ProcessStatusEffectData(statusEffect, packet.pCStruct.PartyId, statusEffect.SourceId, buffList, StatusEffect.StatusEffectType.Party);
            }
            OnChange?.Invoke();
        }

        private void ProcessStatusEffectData(StatusEffectData effectData, UInt64 targetId, UInt64 sourceId, ConcurrentDictionary<UInt64, StatusEffect> effectList, StatusEffect.StatusEffectType effectType)
        {
            
            var buff = new StatusEffect { Started = DateTime.UtcNow, StatusEffectId = effectData.StatusEffectId, InstanceId = effectData.EffectInstanceId, SourceId = sourceId, TargetId = targetId, Type = effectType };
            // end this buf now, it got refreshed
            if (effectList.Remove(buff.InstanceId, out var oldBuff))
            {
                var calcNow = DateTime.UtcNow;
                var duration = calcNow - oldBuff.Started;
                OnStatusEffectEnded?.Invoke(oldBuff, duration, calcNow);
            }
            effectList.TryAdd(buff.InstanceId, buff);
        }

        public void Process(PKTStatusEffectAddNotify effect)
        {
            var buffList = GetBuffList(effect.ObjectId);//get by targetId
            ProcessStatusEffectData(effect.statusEffectData, effect.ObjectId, effect.statusEffectData.SourceId, buffList, StatusEffect.StatusEffectType.Local);
            OnChange?.Invoke();
        }

        public void Process(PKTPartyStatusEffectAddNotify effect)
        {
            foreach (var statusEffect in effect.statusEffectDatas)
            {
                var applierId = statusEffect.SourceId;
                if (effect.PlayerIdOnRefresh != 0x0)
                    applierId = effect.PlayerIdOnRefresh;
                var buffList = GetBuffList(applierId);
                ProcessStatusEffectData(statusEffect, effect.PartyId, applierId, buffList, StatusEffect.StatusEffectType.Party);
            }
            OnChange?.Invoke();
        }

        public void Process(PKTPartyStatusEffectRemoveNotify effect)
        {
            var buffList = GetBuffList(effect.PartyId);
            foreach (var effectInstanceId in effect.StatusEffectIds)
            {
                if (buffList.Remove(effectInstanceId, out var oldBuff))
                {
                    var calcNow = DateTime.UtcNow;
                    var duration = (calcNow - oldBuff.Started);
                    OnStatusEffectEnded?.Invoke(oldBuff, duration, calcNow);
                }
            }
            OnChange?.Invoke();
        }

        public void Process(PKTStatusEffectRemoveNotify effect)
        {
            var buffList = GetBuffList(effect.ObjectId);
            foreach (var effectInstanceId in effect.InstanceIds)
            {
                if (buffList.Remove(effectInstanceId, out var oldBuff))
                {
                    var calcNow = DateTime.UtcNow;
                    var duration = (calcNow - oldBuff.Started);
                    OnStatusEffectEnded?.Invoke(oldBuff, duration, calcNow);
                }
            }
            OnChange?.Invoke();
        }

        public void Process(PKTDeathNotify packet)
        {
            if(BuffMap.Remove(packet.TargetId, out var buffList))
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
            if (!BuffMap.TryGetValue(targetId, out var buffList))
            {
                buffList = new ConcurrentDictionary<UInt64, StatusEffect>();
                BuffMap.TryAdd(targetId, buffList);
            }
            return buffList;
        }

    }
}
