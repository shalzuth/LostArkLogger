using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpc_1_2_2
    {
        public void SteamDecode(BitReader reader)
        {
            num = reader.ReadUInt32();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(reader.ReadByte());
            }
        }
    }
}
