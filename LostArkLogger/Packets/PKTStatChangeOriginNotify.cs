using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public class PKTStatChangeOriginNotify
    {
        // 01-00-01-22-5D-01-79-39-03-00-04-01-00-01-72-09-8B-41-B1-75-03-00-00-00
        public UInt64 PlayerId;
        public UInt64 HealAmount;
        public UInt64 NewHealth;
        public PKTStatChangeOriginNotify(Byte[] Bytes)
        {
            var bitReader = new BitReader(Bytes);
            var unk = bitReader.ReadUInt16();
            var stat1 = bitReader.ReadByte();
            NewHealth = bitReader.ReadPackedInt();
            var baseHealingMaybe = bitReader.ReadPackedInt();
            var unk3 = bitReader.ReadPackedInt();

            var unk2 = bitReader.ReadUInt16();
            var stat12 = bitReader.ReadByte();
            HealAmount = bitReader.ReadPackedInt();

            PlayerId = bitReader.ReadUInt64();
        }
    }
}
