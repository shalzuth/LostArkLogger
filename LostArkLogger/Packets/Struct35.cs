using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct35
    {
        public Struct35(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0.Add(reader.ReadByte());
            }
        }
        public UInt16 num; //48
        public List<Byte> field0 = new List<Byte>(); //0
    }
}
