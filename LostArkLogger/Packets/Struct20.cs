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
                field0s.Add(reader.ReadPackedInt());
                field1s.Add(reader.ReadByte());
            }
        }
        public UInt16 num;
        public List<Int64> field0s = new List<Int64>();
        public List<Byte> field1s = new List<Byte>();
    }
}
