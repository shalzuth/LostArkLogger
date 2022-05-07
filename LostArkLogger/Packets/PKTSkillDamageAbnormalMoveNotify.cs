using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public class PKTSkillDamageAbnormalMoveNotify : PKTSkillDamageNotify
    {
        public PKTSkillDamageAbnormalMoveNotify(Byte[] Bytes)
        {
            // need to fix still
            var bitReader = new BitReader(Bytes);
            PlayerId = bitReader.ReadUInt64();
            NumEvents = bitReader.ReadUInt16();
            Events = new List<PKTSkillDamageNotify.SkillDamageNotifyEvent>();
            for (var i = 0; i < NumEvents; i++)
            {
                var dmgEvent = new PKTSkillDamageNotify.SkillDamageNotifyEvent();
                dmgEvent.TargetId = bitReader.ReadUInt64();
                var four = bitReader.ReadByte();
                var counter = bitReader.ReadUInt16();
                var x1 = bitReader.ReadUInt16(); // BitConverter.ToSingle(BitConverter.GetBytes(bitReader.ReadBits(4 + dmgEvent.DamageBits * 4)), 0);
                var y1 = bitReader.ReadUInt16();
                var t1 = bitReader.ReadUInt32(); // seems to swap between 30ff 33ff 3000 and variations
                var x2 = bitReader.ReadUInt16();
                var y2 = bitReader.ReadUInt16();
                var t2 = bitReader.ReadUInt32();
                var yaw1 = bitReader.ReadUInt16();
                var yaw2 = bitReader.ReadUInt16();
                var knockFlags = bitReader.ReadByte();
                // need to properly parse all these out, i.e. stand up time, down time, freeze time, how high.

                if (knockFlags == 0x29 || knockFlags == 0x7)
                {
                    var _29unk1 = bitReader.ReadUInt64();
                }
                if (knockFlags == 0x6)
                {
                    var _6unk1 = bitReader.ReadUInt32();
                }
                if (knockFlags == 0x37)
                {
                    var _37unk1 = bitReader.ReadUInt64();
                    var _37unk2 = bitReader.ReadUInt64();
                }
                if (knockFlags == 0x17)
                {
                    var _17unk1 = bitReader.ReadUInt32();
                    var _17unk2 = bitReader.ReadUInt64();
                }

                var unk1 = bitReader.ReadUInt32();
                var unk2 = bitReader.ReadUInt32();
                var unk3 = bitReader.ReadUInt32();

                dmgEvent.DamageBits = (UInt16)bitReader.ReadBits(4);
                dmgEvent.Damage = bitReader.ReadBits(4 + dmgEvent.DamageBits * 4);
                var a = (UInt16)bitReader.ReadBits(1);
                var b = (UInt16)(bitReader.ReadBits(3) << 1);
                var c = bitReader.ReadBits(4 + b * 4);
                var d = (UInt16)bitReader.ReadBits(4);
                var e = bitReader.ReadBits(4 + d * 4);
                dmgEvent.FlagsMaybe = bitReader.ReadUInt16();
                dmgEvent.Unk3 = (UInt32)bitReader.ReadUInt16();
                var extra = bitReader.ReadByte();
                for (var j = 0; j < extra; j++) bitReader.ReadByte();
                //extra = bitReader.ReadByte();
                Events.Add(dmgEvent);
            }
            SkillIdWithState = bitReader.ReadUInt32();
            SkillId = bitReader.ReadUInt32();
            bitReader.ReadByte();
        }
    }
}
