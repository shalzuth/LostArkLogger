using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public class PKTStatusEffectAddNotify
    {
        // bytes 10-13
        public UInt32 BuffId;
        /***
         * This is either the level of the tripod
         * or the level of the skill if the buff comes directly from the base skill
         * like Heavenly Tune
         * byte 14
         ***/
        public byte BuffLevel;
        // bytes 15-18
        public UInt32 InstanceId;
        // bytes 25-32
        public UInt64 SourceId;
        // bytes 52-59
        public UInt64 TargetId;

        /***
         * 00-B4-47-C4-A3-00-00-00-00
         * 0-8 Unknow
         * 15-37-03-00
         * 9-12 Buff Id
         * 01
         * 13 Buff Level (Tripod level or skill level)
         * C5-B3-32-06
         * 15-17 Buff Instance Id
         * 00-00-00-80-40-01
         * 18-23 Unknown
         * 74-5D-C4-A3-00-00-00-00
         * 24-31 Source Instance Id (like player, maybe bosses if they can debuff? Need to make a log of argos)
         * E6-57-49-8E-21-49-00-00-CB-49-EC-1B-00-00-00-00
         * 32-47 Unknown
         * -01-
         * 48 Marker Byte, if this is 0x01 there are 16 bytes after
         * 0F-5D-00-00-00-00-00-00-0F-5D-00-00-00-00-00-00
         * 49-64 Unknow extra data
         * -01-00-
         * 65-66 Marker Bytes, if this is 0x01 0x00 there is an extra 7 bytes following
         * -4E-52-00-00-03-00-08-
         * 67-73 Unknown extra data
         * 74-5D-C4-A3-00-00-00-00
         * 74-81 Player/Mob Target Id
         ***/
        public PKTStatusEffectAddNotify(Byte[] bytes)
        {
            int targetIdPosition = 48 + 3;
            int nextMarker = 49;
            if (bytes[48] == 0x01)
            {
                targetIdPosition += 16;
                nextMarker += 16;
            }
            if (bytes[nextMarker] == 0x01 && bytes[nextMarker + 1] == 0x00)
            {
                targetIdPosition += 7;
            }
            BuffId = BitConverter.ToUInt32(bytes, 9);
            BuffLevel = bytes[13];
            InstanceId = BitConverter.ToUInt32(bytes, 14);
            SourceId = BitConverter.ToUInt64(bytes, 24);
            TargetId = BitConverter.ToUInt64(bytes, targetIdPosition);
        }


    }
}
