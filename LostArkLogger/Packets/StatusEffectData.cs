using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class StatusEffectData
    {
        public StatusEffectData(BitReader reader)
        {
            BuffId = reader.ReadUInt32();
            StartTime = reader.ReadUInt32();
            field2 = reader.ReadSimpleInt();
            field3 = reader.ReadUInt32();
            SourceId = reader.ReadUInt64();
            hasfield5 = reader.ReadByte();
            if (hasfield5 == 1)
                field5 = reader.ReadUInt64();
            Level = reader.ReadByte();
            InstanceId = reader.ReadUInt64();
            hasValue = reader.ReadByte();
            if (hasValue == 1)
                Value = reader.ReadBytes(16);
            field9 = new Struct14(reader);
            field10 = reader.ReadByte();
        }
        public UInt32 BuffId;
        public UInt32 StartTime;
        public UInt64 field2;
        public UInt32 field3;
        public UInt64 SourceId;
        public Byte hasfield5;
        public UInt64 field5;
        public Byte Level;
        public UInt64 InstanceId;
        public Byte hasValue;
        public Byte[] Value;
        public Struct14 field9;
        public Byte field10;
    }
}
