using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTRemoveObject
    {
        public PKTRemoveObject(BitReader reader)
        {
            field0 = reader.ReadString();
            field1 = reader.ReadUInt64();
        }
        public String field0;
        public UInt64 field1;
    }
}
