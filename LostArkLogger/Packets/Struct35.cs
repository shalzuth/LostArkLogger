using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct35
    {
        public Struct35(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(new Struct36(reader));
                field1s.Add(new Struct37(reader));
                field2s.Add(new Struct38(reader));
            }
        }
        public UInt16 num;
        public List<Struct36> field0s = new List<Struct36>();
        public List<Struct37> field1s = new List<Struct37>();
        public List<Struct38> field2s = new List<Struct38>();
    }
}
