using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct12
    {
        public Struct12(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(new Struct13(reader));
            }
        }
        public UInt16 num;
        public List<Struct13> field0s = new List<Struct13>();
    }
}
