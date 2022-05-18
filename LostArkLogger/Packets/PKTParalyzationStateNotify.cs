using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTParalyzationStateNotify
    {
        public PKTParalyzationStateNotify(BitReader reader)
        {
            field0 = reader.ReadBytes(32);
        }
        public Byte[] field0;
    }
}
