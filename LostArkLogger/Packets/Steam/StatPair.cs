using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatPair
    {
        public void SteamDecode(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                StatType.Add(reader.ReadByte());
                // FIXME: Produces incorrect values but Name is now correct
                Value.Add(reader.ReadUInt16());
            }
        }
    }
}
