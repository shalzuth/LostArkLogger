using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public class PKTStatusEffectRemoveNotify
    {

        /***
         * There seems to be a marker byte with multiple possible values
         * from which the data starts
         * marker + 1 to marker + 8
         ***/
        public UInt64 TargetId;
        /***
         * the two bytes after target id are for the amount
         * of buff ids.
         * Then afterwards buff ids follow as 4 bytes each
         ***/
        public IReadOnlyCollection<UInt32> BuffInstanceIds;
        /***
         * 00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00
         * Unknown sometimes not even there
         * -05-
         * First none 0x00 byte Unknown, seen values 0x03 0x05 0x01
         * D3-7E-ED-18-01-00-00-00
         * Next 8 bytes are TargetId of the Buffs
         * -01-00-
         * Thse 2 bytes are the amount of buffs
         * 7E-7C-EF-08
         * Next bytes are in 4 bytes size, instance ids of buffs
         */
        public PKTStatusEffectRemoveNotify(Byte[] bytes)
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
            TargetId = BitConverter.ToUInt64(bytes, startIndex + 1);
            UInt16 amount = BitConverter.ToUInt16(bytes, startIndex + 9);
            List<UInt32> buffInstances = new List<UInt32>();
            for (int i = 0; i < amount; i++)
            {
                buffInstances.Add(BitConverter.ToUInt32(bytes, startIndex + 11 + 4 * i));
            }
            BuffInstanceIds = buffInstances;
        }
    }
}
