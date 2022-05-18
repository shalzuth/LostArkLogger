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
                field0s.Add(new Struct11(reader));
                field1s.Add(reader.ReadUInt32());
            }
        }
        public UInt16 num;
        public List<Struct11> field0s = new List<Struct11>();
        public List<UInt32> field1s = new List<UInt32>();
    }
}
