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
                field0.Add(new Struct37(reader));
                field1.Add(new Struct38(reader));
                field2.Add(new Struct35(reader));
            }
        }
        public UInt16 num; //0
        public List<Struct37> field0 = new List<Struct37>(); //0
        public List<Struct38> field1 = new List<Struct38>(); //66
        public List<Struct35> field2 = new List<Struct35>(); //196
    }
}
