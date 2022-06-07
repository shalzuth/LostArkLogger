using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitEnv
    {
        public void SteamDecode(BitReader reader)
        {
            pKTInitEnv_1 = reader.Read<PKTInitEnv_1>();
            field1 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
            field3 = reader.ReadUInt64();
            field4 = reader.ReadSimpleInt();
            field5 = reader.ReadUInt32();
            field6 = reader.ReadUInt32();
            field7 = reader.ReadList<Byte>();
        }
    }
}
