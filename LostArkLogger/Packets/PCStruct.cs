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
        public Byte field0; //0
        public Struct7 field1; //1
        public UInt32 field2; //1804
        public Byte field3; //1808
        public UInt16 field4; //1810
        public Byte[] field5; //1812
        public UInt64 field6; //1840
        public Byte field7; //1848
        public Struct10 field8; //64
        public Struct12 field9; //7451
        public Byte field10; //18333
        public UInt64 field11; //18334
        public UInt32 field12; //18342
        public UInt16 field13; //18346
        public Byte field14; //18348
        public String field15; //18349
        public Byte field16; //18391
        public Byte field17; //18392
        public Struct15 field18; //18393
        public UInt32 field19; //18676
        public UInt16 ClassId; //18680
        public UInt32 field21; //18684
        public Byte hasfield22; //18700
        public Byte[] field22; //18688
        public UInt32 field23; //18704
        public UInt16 field24; //18708
        public UInt32 field25; //18712
        public Struct17 field26; //18716
        public Struct18 field27; //19518
        public UInt32 field28; //20060
        public Byte field29; //20064
        public UInt64 PlayerId; //20072
        public Byte field31; //20080
        public UInt16 field32; //20082
        public String Name; //20084
        public UInt32 field34; //20128
        public Struct19 field35; //20132
        public Byte field36; //20648
        public Struct20 field37; //64
        public UInt32 field38; //24300
        public Byte field39; //24304
        public UInt32 field40; //24308
        public Byte field41; //24312
    }
}
