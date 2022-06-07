using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTDeathNotify
    {
        public void SteamDecode(BitReader reader)
        {
            field0 = reader.ReadByte();
            field1 = reader.ReadUInt32();
            hasfield2 = reader.ReadByte();
            if (hasfield2 == 1)
                field2 = reader.ReadByte();
            hasfield3 = reader.ReadByte();
            if (hasfield3 == 1)
                field3 = reader.ReadByte();
            field4 = reader.ReadUInt16();
            hasfield5 = reader.ReadByte();
            if (hasfield5 == 1)
                field5 = reader.ReadByte();
            SourceId = reader.ReadUInt64();
            field7 = reader.ReadUInt64();
            TargetId = reader.ReadUInt64();
        }
    }
}
