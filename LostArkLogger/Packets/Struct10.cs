using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct10
    {
        public Struct10(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(reader.ReadBytes(14));
            }
        }
        public UInt16 num;
        public List<Byte[]> field0s = new List<Byte[]>();
    }
}
