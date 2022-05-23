using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class NpcStruct
    {
        public NpcStruct(BitReader reader)
        {
            NpcId = reader.ReadUInt64();
            hasfield1 = reader.ReadByte();
            if (hasfield1 == 1)
                field1 = reader.ReadByte();
            hasfield2 = reader.ReadByte();
            if (hasfield2 == 1)
                field2 = reader.ReadByte();
            hasfield3 = reader.ReadByte();
            if (hasfield3 == 1)
                field3 = reader.ReadUInt16();
            hasfield4 = reader.ReadByte();
            if (hasfield4 == 1)
                field4 = reader.ReadByte();
            hasfield5 = reader.ReadByte();
            if (hasfield5 == 1)
                field5 = reader.ReadUInt32();
            field6 = reader.ReadByte();
            hasfield7 = reader.ReadByte();
            if (hasfield7 == 1)
                pKTNewNpc_1_1 = reader.Read<PKTNewNpc_1_1>();
            hasfield8 = reader.ReadByte();
            if (hasfield8 == 1)
                field8 = reader.ReadUInt32();
            hasfield9 = reader.ReadByte();
            if (hasfield9 == 1)
                field9 = reader.ReadUInt64();
            field10 = reader.ReadUInt16();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            hasfield12 = reader.ReadByte();
            if (hasfield12 == 1)
                field12 = reader.ReadList<Byte[]>(12);
            NpcType = reader.ReadUInt32();
            statPair = reader.Read<StatPair>();
            hasfield15 = reader.ReadByte();
            if (hasfield15 == 1)
                field15 = reader.ReadByte();
            field16 = reader.ReadByte();
            field17 = reader.ReadByte();
            hasfield18 = reader.ReadByte();
            if (hasfield18 == 1)
                field18 = reader.ReadUInt32();
            field19 = reader.ReadUInt32();
            hasfield20 = reader.ReadByte();
            if (hasfield20 == 1)
                field20 = reader.ReadByte();
            hasfield21 = reader.ReadByte();
            if (hasfield21 == 1)
                field21 = reader.ReadUInt32();
            pKTNewNpc_1_5_1s = reader.ReadList<PKTNewNpc_1_5_1>();
            field23 = reader.ReadByte();
            field24 = reader.ReadUInt16();
            field25 = reader.ReadUInt64();
            field26 = reader.ReadByte();
            hasfield27 = reader.ReadByte();
            if (hasfield27 == 1)
                field27 = reader.ReadList<UInt64>();
            field28 = reader.ReadByte();
            hasfield29 = reader.ReadByte();
            if (hasfield29 == 1)
                field29 = reader.ReadByte();
            hasfield30 = reader.ReadByte();
            if (hasfield30 == 1)
                field30 = reader.ReadByte();
            hasfield31 = reader.ReadByte();
            if (hasfield31 == 1)
                field31 = reader.ReadUInt32();
            hasfield32 = reader.ReadByte();
            if (hasfield32 == 1)
                field32 = reader.ReadUInt16();
        }
        public UInt64 NpcId;
        public Byte hasfield1;
        public Byte field1;
        public Byte hasfield2;
        public Byte field2;
        public Byte hasfield3;
        public UInt16 field3;
        public Byte hasfield4;
        public Byte field4;
        public Byte hasfield5;
        public UInt32 field5;
        public Byte field6;
        public Byte hasfield7;
        public PKTNewNpc_1_1 pKTNewNpc_1_1;
        public Byte hasfield8;
        public UInt32 field8;
        public Byte hasfield9;
        public UInt64 field9;
        public UInt16 field10;
        public List<StatusEffectData> statusEffectDatas;
        public Byte hasfield12;
        public List<Byte[]> field12;
        public UInt32 NpcType;
        public StatPair statPair;
        public Byte hasfield15;
        public Byte field15;
        public Byte field16;
        public Byte field17;
        public Byte hasfield18;
        public UInt32 field18;
        public UInt32 field19;
        public Byte hasfield20;
        public Byte field20;
        public Byte hasfield21;
        public UInt32 field21;
        public List<PKTNewNpc_1_5_1> pKTNewNpc_1_5_1s;
        public Byte field23;
        public UInt16 field24;
        public UInt64 field25;
        public Byte field26;
        public Byte hasfield27;
        public List<UInt64> field27;
        public Byte field28;
        public Byte hasfield29;
        public Byte field29;
        public Byte hasfield30;
        public Byte field30;
        public Byte hasfield31;
        public UInt32 field31;
        public Byte hasfield32;
        public UInt16 field32;
    }
}
