using System;
namespace LostArkLogger
{
    public class PKTParalyzationStateNotify
    {
        public UInt64 TargetId;
        public UInt32 ParalyzationPointMax;
        public UInt32 ParalyzationPoint;
        public PKTParalyzationStateNotify(Byte[] Bytes)
        {
            TargetId = BitConverter.ToUInt32(Bytes, 0);
            ParalyzationPointMax = BitConverter.ToUInt32(Bytes, 13);
            ParalyzationPoint = BitConverter.ToUInt32(Bytes, 22);
        }
    }
}
