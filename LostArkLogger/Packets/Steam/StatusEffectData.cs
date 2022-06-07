using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class StatusEffectData
    {
        public void SteamDecode(BitReader reader)
        {
            field0 = reader.ReadUInt32();
            field1 = reader.ReadByte();
            field2 = reader.ReadByte();
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
            InstanceId = reader.ReadUInt64();
            BuffId = reader.ReadUInt32();
            field6 = reader.ReadList<Byte[]>(7);
            field7 = reader.ReadUInt32();
            field8 = reader.ReadSimpleInt();
            hasfield9 = reader.ReadByte();
            if (hasfield9 == 1)
                field9 = reader.ReadUInt64();
            SourceId = reader.ReadUInt64();
        }
    }
}
