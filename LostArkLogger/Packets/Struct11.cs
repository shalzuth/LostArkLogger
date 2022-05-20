using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct11
    {
        public Struct11(BitReader reader)
        {
            num = reader.ReadUInt32();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(reader.ReadByte());
            }
        }
        public UInt32 num;
        public List<Byte> field0s = new List<Byte>();
    }
}
