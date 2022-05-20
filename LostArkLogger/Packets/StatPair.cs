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
                StatTypes.Add(reader.ReadByte());
                Values.Add(reader.ReadPackedInt());
            }
        }
        public UInt16 num;
        public List<Byte> StatTypes = new List<Byte>();
        public List<Int64> Values = new List<Int64>();
    }
}
