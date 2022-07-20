using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc5
    {
        public void KoreaDecode(BitReader reader)
        {
            num = reader.ReadUInt32();
            for(var i = 0; i < num; i++)
            {
                b_0.Add(reader.ReadByte());
            }
        }
    }
}
