using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct7
    {
        public Struct7(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(new Struct8(reader));
            }
        }
        public UInt16 num;
        public List<Struct8> field0s = new List<Struct8>();
    }
}
