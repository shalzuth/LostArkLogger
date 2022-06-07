using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class SkillRunes
    {
        public void SteamDecode(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(reader.ReadList<UInt32>());
                field1s.Add(reader.ReadUInt32());
            }
        }
    }
}
