using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class StatusEffectData
    {
        public StatusEffectData(BitReader reader)
        {
            BuffId = reader.ReadUInt32();
            field1 = reader.ReadByte();
            SourceId = reader.ReadUInt64();
            field3 = reader.ReadUInt32();
            InstanceId = reader.ReadUInt64();
            hasfield5 = reader.ReadByte();
            if (hasfield5 == 1)
                Value = reader.ReadBytes(16);
            field6 = reader.ReadSimpleInt();
            field7 = reader.ReadUInt32();
            hasfield8 = reader.ReadByte();
            if (hasfield8 == 1)
                field8 = reader.ReadUInt64();
            field9 = reader.ReadByte();
            field10 = reader.ReadList<Byte[]>(7);
        }
        public UInt32 BuffId;
        public Byte field1;
        public UInt64 SourceId;
        public UInt32 field3;
        public UInt64 InstanceId;
        public Byte hasfield5;
        public Byte[] Value;
        public UInt64 field6;
        public UInt32 field7;
        public Byte hasfield8;
        public UInt64 field8;
        public Byte field9;
        public List<Byte[]> field10;
    }
}
