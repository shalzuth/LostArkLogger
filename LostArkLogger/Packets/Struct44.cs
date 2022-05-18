using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct44
    {
        public Struct44(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0.Add(reader.ReadBytes(30));
            }
        }
        public UInt16 num; //0
        public List<Byte[]> field0 = new List<Byte[]>(); //2
    }
}
