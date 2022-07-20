using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillRunes
    {
        public void KoreaDecode(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                u32_0.Add(reader.ReadUInt32());
                u32list_0.Add(reader.ReadList<UInt32>());
            }
        }
    }
}
