using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTRemoveObject
    {
        public PKTRemoveObject(BitReader reader)
        {
            field0 = reader.ReadUInt64();
            field1 = reader.ReadString();
        }
        public UInt64 field0;
        public String field1;
    }
}
