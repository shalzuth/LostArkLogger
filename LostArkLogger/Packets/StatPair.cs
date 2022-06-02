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
                Value.Add(reader.ReadPackedInt());
                StatType.Add(reader.ReadByte());
            }
        }
        public UInt16 num;
        public List<Int64> Value = new List<Int64>();
        public List<Byte> StatType = new List<Byte>();
    }
}
