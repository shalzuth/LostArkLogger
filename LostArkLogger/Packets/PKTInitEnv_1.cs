using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTInitEnv_1
    {
        public PKTInitEnv_1(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(reader.ReadList<Byte>());
                field1s.Add(reader.ReadList<Byte>());
                field2s.Add(reader.ReadList<Byte>());
            }
        }
        public UInt16 num;
        public List<List<Byte>> field0s = new List<List<Byte>>();
        public List<List<Byte>> field1s = new List<List<Byte>>();
        public List<List<Byte>> field2s = new List<List<Byte>>();
    }
}
