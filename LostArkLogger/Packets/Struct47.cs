using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct47
    {
        public Struct47(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(reader.ReadBytes(16));
            }
        }
        public UInt16 num;
        public List<Byte[]> field0s = new List<Byte[]>();
    }
}
