using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatPair
    {
        public void KoreaDecode(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                StatType.Add(reader.ReadByte());
                Value.Add(reader.ReadPackedInt());
            }
        }
    }
}
