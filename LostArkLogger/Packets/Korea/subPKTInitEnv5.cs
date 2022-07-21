using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTInitEnv5
    {
        public void KoreaDecode(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                blist_2.Add(reader.ReadList<Byte>());
                blist_1.Add(reader.ReadList<Byte>());
                blist_0.Add(reader.ReadList<Byte>());
            }
        }
    }
}
