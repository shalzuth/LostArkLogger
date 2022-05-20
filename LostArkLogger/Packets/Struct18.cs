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
                field0s.Add(new Struct19(reader));
                field1s.Add(reader.ReadUInt32());
            }
        }
        public UInt16 num;
        public List<Struct19> field0s = new List<Struct19>();
        public List<UInt32> field1s = new List<UInt32>();
    }
}
