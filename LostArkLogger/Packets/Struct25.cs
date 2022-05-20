using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct25
    {
        public Struct25(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(reader.ReadUInt64());
            }
        }
        public UInt16 num;
        public List<UInt64> field0s = new List<UInt64>();
    }
}
