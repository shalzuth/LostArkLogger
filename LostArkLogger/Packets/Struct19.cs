using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct19
    {
        public Struct19(BitReader reader)
        {
            num = reader.ReadUInt32();
            for(var i = 0; i < num; i++)
            {
                field0.Add(reader.ReadByte());
            }
        }
        public UInt32 num; //512
        public List<Byte> field0 = new List<Byte>(); //0
    }
}
