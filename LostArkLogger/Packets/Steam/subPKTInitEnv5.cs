using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTInitEnv5
    {
        public void SteamDecode(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                blist_1.Add(reader.ReadList<Byte>());
                blist_2.Add(reader.ReadList<Byte>());
                blist_0.Add(reader.ReadList<Byte>());
            }
        }
    }
}
