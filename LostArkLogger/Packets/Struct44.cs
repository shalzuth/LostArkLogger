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
                field0s.Add(reader.ReadBytes(30));
            }
        }
        public UInt16 num;
        public List<Byte[]> field0s = new List<Byte[]>();
    }
}
