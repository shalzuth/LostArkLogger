using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public class PKTSkillDamageNotify
    {
        // FC-8F-0F-00-01-C1-35-05-21-00-00-00-00-66-8E-01-00-01-00-E1-89-05-21-00-00-00-00-A2-02-E4-49-0A-84-4C-0A-00-00-00-00-00
        public UInt32 SkillIdWithState; // 360003
        public UInt32 SkillId; // 36000
        public UInt16 NumEvents; // 0x0001
        public List<SkillDamageNotifyEvent> Events;
        public UInt64 PlayerId;
        public class SkillDamageNotifyEvent
        {
            public UInt64 TargetId;
            public UInt64 Damage;
            public ModifierFlag Modifier;
        }
        public PKTSkillDamageNotify() { }
        public PKTSkillDamageNotify(Byte[] Bytes)
        {
            var bitReader = new BitReader(Bytes);
            SkillId = bitReader.ReadUInt32();
            PlayerId = bitReader.ReadUInt64();
            SkillIdWithState = bitReader.ReadUInt32();
            bitReader.ReadByte();
            NumEvents = bitReader.ReadUInt16();
            Events = new List<SkillDamageNotifyEvent>();
            for (var i = 0; i < NumEvents; i++)
            {
                var dmgEvent = new SkillDamageNotifyEvent();
                dmgEvent.Damage = (ulong) bitReader._ReadInt64NBytes(bitReader.ReadByte());
                if (bitReader.ReadByte() == 1)
                    bitReader.ReadByte();
                bitReader.ReadByte();
                bitReader.ReadUInt16();
                dmgEvent.Modifier = (ModifierFlag) bitReader.ReadByte();
                bitReader._ReadInt64NBytes(bitReader.ReadByte());
                bitReader._ReadInt64NBytes(bitReader.ReadByte());
                dmgEvent.TargetId = bitReader.ReadUInt64();
                Events.Add(dmgEvent);
            }
        }

        [Flags]
        public enum
            ModifierFlag // 0b**FBKD*C with F: front attack, B: Back attack, K: bleed crit (dots ?), D: bleed not crit (dots ?), C: crit
        {
            None = 0,
            SkillCrit = 1,
            UnkModifier1 = 2,
            DotNoCrit = 4,
            DotCrit = 8,
            BackAttack = 16,
            FrontAttack = 32,
            UnkModifier2 = 64,
            UnkModifier3 = 128
        }
    }
}
