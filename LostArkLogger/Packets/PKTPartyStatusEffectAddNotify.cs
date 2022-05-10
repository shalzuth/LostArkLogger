using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public class PKTPartyStatusEffectAddNotify
    {
        // 11-14
        public UInt32 BuffId;
        // 15
        public byte BuffLevel;
        // 16-19
        public UInt32 InstanceId;
        // 26-33
        public UInt64 SourceId;
        // 54-61
        public UInt64 TargetPlayerPartyId;
        /***
         * 00-00-00-00-00-00-00-00
         * 0-7 Unknown
         * -01-00-
         * 8-9 amount bits (weirdly this seem to already be party of the repetion amount and even 1 byte before)
         * 1D-9F-02-00
         * 10-13 Buff Id
         * -01-
         * 14 Buff level
         * D2-FF-24-0A
         * 15-18 Buff Instance Id
         * -00-9A-99-59-40-01-
         * 19-24 Unknown
         * D3-8E-DC-1D-01-00-00-00-
         * 25-32 SourceId
         * E6-57-29-06-CD-85-00-00-45-EC-95-1B-00-00-00-00-
         * 33-48 Unknow, finaly bits of repetition length
         * -01-
         * 49 Marker byte if 0x01 there is 16 bytes added after it
         * 6C-81-00-00-00-00-00-00-6C-81-00-00-00-00-00-00
         * 50-65 Unknown extra bytes
         * -01-
         * 66 Marker byte, if 0x01 there is 5 extra bytes added after it
         * -00-1C-43-00-00
         * 67-71 Unknown extra bytes
         * -03-00-06-00-
         * 72-75 Unknown
         * D6-CB-06-00-00-00-00-00
         * 76-83 TargetPartyId
         ***/
        public PKTPartyStatusEffectAddNotify(Byte[] bytes)
        {
            UInt16 amount = BitConverter.ToUInt16(bytes, 8);
            int targetIdIndex = 7 + amount * 42 + 4;
            int nextMarker = 50;
            if (bytes[49] == 0x01)
            {
                nextMarker += 16;
                targetIdIndex += 16;
            }
            if (bytes[nextMarker] == 0x01)
            {
                targetIdIndex += 7;
            }
            BuffId = BitConverter.ToUInt32(bytes, 10);
            BuffLevel = bytes[14];
            InstanceId = BitConverter.ToUInt32(bytes, 15);
            SourceId = BitConverter.ToUInt64(bytes, 25);
            TargetPlayerPartyId = BitConverter.ToUInt64(bytes, targetIdIndex);
        }
    }
}
