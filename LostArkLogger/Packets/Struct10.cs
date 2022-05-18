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
                field0.Add(new Struct11(reader));
                field1.Add(reader.ReadUInt32());
            }
        }
        public UInt16 num; //0
        public List<Struct11> field0 = new List<Struct11>(); //0
        public List<UInt32> field1 = new List<UInt32>(); //24
    }
}
