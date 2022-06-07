using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitEnv_1
    {
        public void SteamDecode(BitReader reader)
        {
            num = reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                field0s.Add(reader.ReadList<Byte>());
                field1s.Add(reader.ReadList<Byte>());
                field2s.Add(reader.ReadList<Byte>());
            }
        }
    }
}
