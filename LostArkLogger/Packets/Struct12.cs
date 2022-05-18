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
                field0.Add(new Struct13(reader));
            }
        }
        public UInt16 num; //0
        public List<Struct13> field0 = new List<Struct13>(); //0
    }
}
