using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct8
    {
        public Struct8(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(new Struct9(reader));
            }
        }
        public UInt16 num;
        public List<Struct9> field0s = new List<Struct9>();
    }
}
