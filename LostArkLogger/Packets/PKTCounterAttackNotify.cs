using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTCounterAttackNotify
    {
        public PKTCounterAttackNotify(BitReader reader)
        {
            field0 = reader.ReadBytes(22);
        }
        public Byte[] field0;
    }
}
