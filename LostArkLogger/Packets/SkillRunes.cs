using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class SkillRunes
    {
        public SkillRunes(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(reader.ReadList<UInt32>());
                field1s.Add(reader.ReadUInt32());
            }
        }
        public UInt16 num;
        public List<List<UInt32>> field0s = new List<List<UInt32>>();
        public List<UInt32> field1s = new List<UInt32>();
    }
}
