using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct18
    {
        public Struct18(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0.Add(new Struct8(reader));
            }
        }
        public UInt16 num; //0
        public List<Struct8> field0 = new List<Struct8>(); //0
    }
}
