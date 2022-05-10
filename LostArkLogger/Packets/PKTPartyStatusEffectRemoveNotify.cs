using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public class PKTPartyStatusEffectRemoveNotify
    {
        /**
         * There can be leading zeros
         * data starts with a leading 0x03 or 0x0B or 0x01 etc
         * Then 2 bytes for the amount
         * Then amount * 4 bytes of partybuff instance ids
         * Then 8 bytes of player party id
         * 00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00
         * Unknown data
         * -0B-
         * Leading byte
         * -01-00-
         * Amount to remove
         * 07-CD-80-09
         * 4 byte Buff ids
         * -59-80-8C-00-00-00-00-00
         * party id to remove it from
         ***/
        public UInt16 Amount;
        public IReadOnlyCollection<UInt32> BuffInstanceIds;
        public UInt64 PlayerPartyId;
        public PKTPartyStatusEffectRemoveNotify(Byte[] bytes)
        {
            int startIndex = -1;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] != 0x00)
                {
                    startIndex = i;
                    break;
                }
            }
            Amount = BitConverter.ToUInt16(bytes, startIndex+1);
            List<UInt32> ids = new List<UInt32>(Amount);
            for (int i = 0; i < Amount; i++)
            {
                ids.Add(BitConverter.ToUInt32(bytes, startIndex + 3 + i * 4));
            }
            PlayerPartyId = BitConverter.ToUInt64(bytes, startIndex + 3 + Amount * 4);
            BuffInstanceIds = ids;
        }
    }
}
