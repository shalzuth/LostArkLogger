using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class ItemInfo
    {
        public void SteamDecode(BitReader reader)
        {
            field0 = reader.ReadList<Byte[]>(14);
            hasfield1 = reader.ReadByte();
            if (hasfield1 == 1)
                field1 = reader.ReadByte();
            field2 = reader.ReadUInt32();
            field3 = reader.ReadUInt16();
            field4 = reader.ReadSimpleInt();
            Level = reader.ReadUInt16();
        }
    }
}
