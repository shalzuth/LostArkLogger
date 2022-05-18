using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class Struct20
    {
        public Struct20(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0.Add(reader.ReadPackedInt());
                field1.Add(reader.ReadByte());
            }
        }
        public UInt16 num; //0
        public List<Int64> field0 = new List<Int64>(); //0
        public List<Byte> field1 = new List<Byte>(); //16
    }
}
