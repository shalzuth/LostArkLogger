using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class StatusEffectData
    {
        public StatusEffectData(BitReader reader)
        {
            field0 = reader.ReadUInt32();
            field1 = reader.ReadByte();
            field2 = reader.ReadByte();
            hasfield3 = reader.ReadByte();
            if (hasfield3 == 1)
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
        public UInt32 field0;
        public Byte field1;
        public Byte field2;
        public Byte hasfield3;
        public Byte[] Value;
        public UInt64 InstanceId;
        public UInt32 BuffId;
        public List<Byte[]> field6;
        public UInt32 field7;
        public UInt64 field8;
        public Byte hasfield9;
        public UInt64 field9;
        public UInt64 SourceId;
    }
}
