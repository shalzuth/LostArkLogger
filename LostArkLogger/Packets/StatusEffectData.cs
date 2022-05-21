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
            field2 = reader.ReadUInt64();
            field3 = reader.ReadUInt32();
            StartTime = reader.ReadUInt64();
            BuffId = reader.ReadByte();
            if (BuffId == 1)
                Value = reader.ReadBytes(16);
            field6 = reader.ReadSimpleInt();
            field7 = reader.ReadUInt32();
            hasfield8 = reader.ReadByte();
            if (hasfield8 == 1)
                field8 = reader.ReadUInt64();
            field9 = reader.ReadByte();
            field10 = reader.ReadList<Byte[]>(7);
        }
        public UInt32 field0;
        public Byte field1;
        public UInt64 field2;
        public UInt32 field3;
        public UInt64 StartTime;
        public Byte BuffId;
        public Byte[] Value;
        public UInt64 field6;
        public UInt32 field7;
        public Byte hasfield8;
        public UInt64 field8;
        public Byte field9;
        public List<Byte[]> field10;
    }
}
