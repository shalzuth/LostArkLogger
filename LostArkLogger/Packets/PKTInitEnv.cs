using System;
namespace LostArkLogger
{
    public class PKTInitEnv
    {
        //01-00-00-FC-FF-FF-FF-00-00-00-00-37-5C-2C-07-00-00-00-00-03-00-55-00-54-00-43-00-E1-89-05-21-00-00-00-00-E6-47-76-BE-06-5B-00-00
        public String UTC;
        public UInt64 PlayerId;
        public PKTInitEnv(Byte[] bytes)
        {
            PlayerId = BitConverter.ToUInt64(bytes, 27);
        }
    }
}
