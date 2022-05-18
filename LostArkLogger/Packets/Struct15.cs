using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct15
    {
        public Struct15(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0.Add(new Struct16(reader));
            }
        }
        public UInt16 num; //0
        public List<Struct16> field0 = new List<Struct16>(); //0
    }
}
