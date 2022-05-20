using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct16
    {
        public Struct16(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(new Struct17(reader));
            }
        }
        public UInt16 num;
        public List<Struct17> field0s = new List<Struct17>();
    }
}
