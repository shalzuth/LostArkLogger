using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public class StatusEffect : IComparable
    {
        public UInt64 InstanceId;
        public UInt32 StatusEffectId;
        // this is party id for party buff otherwise entity id
        public UInt64 TargetId;
        public UInt64 SourceId;
        public DateTime Started;
        public StatusEffectType Type;
        public Int32 Value; // for shield amount, etc.

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is StatusEffect statusEffect)
            {
                if (InstanceId == statusEffect.InstanceId) return 0;
                if (InstanceId < statusEffect.InstanceId) return -1;
                return 1;
            }
            else
            {
                throw new ArgumentException("Object is not a StatusEffect");
            }
        }

        public override int GetHashCode()
        {
            return (int)InstanceId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (obj is StatusEffect buff)
            {
                return buff.InstanceId == this.InstanceId;
            }
            else
            {
                throw new ArgumentException("Object is not a StatusEffect");
            }
        }
        public override string ToString()
        {
            return $"IID: {InstanceId:X} | StatusEffectId: {StatusEffectId:X} | tID: {TargetId:X} | sID: {SourceId:X} | Type: {Type}";
        }

        public enum StatusEffectType
        {
            Party,
            Local
        }


    }
}
