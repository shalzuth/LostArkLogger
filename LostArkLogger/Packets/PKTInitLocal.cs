using System;

namespace LostArkLogger.Packets
{
    public class PKTInitLocal
    {
        //00 00 03 00 55 00 54 00 43 00 AA EB BB 93 00 00 00 00 E6 57 86 5D 01 6B 00 00 01 00 00 00 01 25 19 24 0B 00 00 00 00 00 00 00 00
        public UInt64 PlayerId;
        public PKTInitLocal(Byte[] bytes)
        {
            PlayerId = BitConverter.ToUInt32(bytes, 1);
        }
    }
}
