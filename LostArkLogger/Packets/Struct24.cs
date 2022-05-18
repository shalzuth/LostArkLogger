using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct24
    {
        public Struct24(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0.Add(reader.ReadUInt32());
            }
        }
        public UInt16 num; //0
        public List<UInt32> field0 = new List<UInt32>(); //2
    }
}
