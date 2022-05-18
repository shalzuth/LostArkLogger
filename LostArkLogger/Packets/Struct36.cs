using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct36
    {
        public Struct36(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(new Struct37(reader));
                field1s.Add(new Struct38(reader));
                field2s.Add(new Struct35(reader));
            }
        }
        public UInt16 num;
        public List<Struct37> field0s = new List<Struct37>();
        public List<Struct38> field1s = new List<Struct38>();
        public List<Struct35> field2s = new List<Struct35>();
    }
}
