using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class StatPair
    {
        public StatPair(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                StatType.Add(reader.ReadByte());
                Value.Add(reader.ReadPackedInt());
            }
        }
        public UInt16 num;
        public List<Byte> StatType = new List<Byte>();
        public List<Int64> Value = new List<Int64>();
    }
}
