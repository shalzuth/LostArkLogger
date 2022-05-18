using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct23
    {
        public Struct23(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0.Add(reader.ReadUInt64());
            }
        }
        public UInt16 num; //0
        public List<UInt64> field0 = new List<UInt64>(); //2
    }
}
