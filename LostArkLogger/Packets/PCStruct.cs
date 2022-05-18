using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PCStruct
    {
        public PCStruct(BitReader reader)
        {
            field0 = reader.ReadByte();
            field1 = new Struct7(reader);
            field2 = reader.ReadUInt32();
            field3 = reader.ReadByte();
            field4 = reader.ReadUInt16();
            field5 = reader.ReadBytes(25);
            field6 = reader.ReadUInt64();
            field7 = reader.ReadByte();
            field8 = new Struct10(reader);
            field9 = new Struct12(reader);
            field10 = reader.ReadByte();
            field11 = reader.ReadUInt64();
            field12 = reader.ReadUInt32();
            field13 = reader.ReadUInt16();
            field14 = reader.ReadByte();
            field15 = reader.ReadString();
            field16 = reader.ReadByte();
            field17 = reader.ReadByte();
            field18 = new Struct15(reader);
            field19 = reader.ReadUInt32();
            ClassId = reader.ReadUInt16();
            field21 = reader.ReadUInt32();
            hasfield22 = reader.ReadByte();
            if (hasfield22 == 1)
                field22 = reader.ReadBytes(12);
            field23 = reader.ReadUInt32();
            field24 = reader.ReadUInt16();
            field25 = reader.ReadUInt32();
            field26 = new Struct17(reader);
            field27 = new Struct18(reader);
            field28 = reader.ReadUInt32();
            field29 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
            field31 = reader.ReadByte();
            field32 = reader.ReadUInt16();
            Name = reader.ReadString();
            field34 = reader.ReadUInt32();
            field35 = new Struct19(reader);
            field36 = reader.ReadByte();
            field37 = new Struct20(reader);
            field38 = reader.ReadUInt32();
            field39 = reader.ReadByte();
            field40 = reader.ReadUInt32();
            field41 = reader.ReadByte();
        }
        public Byte field0;
        public Struct7 field1;
        public UInt32 field2;
        public Byte field3;
        public UInt16 field4;
        public Byte[] field5;
        public UInt64 field6;
        public Byte field7;
        public Struct10 field8;
        public Struct12 field9;
        public Byte field10;
        public UInt64 field11;
        public UInt32 field12;
        public UInt16 field13;
        public Byte field14;
        public String field15;
        public Byte field16;
        public Byte field17;
        public Struct15 field18;
        public UInt32 field19;
        public UInt16 ClassId;
        public UInt32 field21;
        public Byte hasfield22;
        public Byte[] field22;
        public UInt32 field23;
        public UInt16 field24;
        public UInt32 field25;
        public Struct17 field26;
        public Struct18 field27;
        public UInt32 field28;
        public Byte field29;
        public UInt64 PlayerId;
        public Byte field31;
        public UInt16 field32;
        public String Name;
        public UInt32 field34;
        public Struct19 field35;
        public Byte field36;
        public Struct20 field37;
        public UInt32 field38;
        public Byte field39;
        public UInt32 field40;
        public Byte field41;
    }
}
