using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct14
    {
        public Struct14(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(reader.ReadBytes(7));
            }
        }
        public UInt16 num;
        public List<Byte[]> field0s = new List<Byte[]>();
    }
}
