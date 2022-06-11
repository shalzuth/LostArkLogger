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
                Value.Add(reader.ReadPackedInt());
                StatType.Add(reader.ReadByte());
            }
        }
    }
}
