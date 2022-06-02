using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class NpcStruct
    {
        public NpcStruct(BitReader reader)
        {
            field0 = reader.ReadUInt16();
            field1 = reader.ReadByte();
            hasfield2 = reader.ReadByte();
            if (hasfield2 == 1)
                field2 = reader.ReadByte();
            hasfield3 = reader.ReadByte();
            if (hasfield3 == 1)
                field3 = reader.ReadUInt32();
            statPair = reader.Read<StatPair>();
            hasfield5 = reader.ReadByte();
            if (hasfield5 == 1)
                field5 = reader.ReadByte();
            hasfield6 = reader.ReadByte();
            if (hasfield6 == 1)
                field6 = reader.ReadByte();
            hasfield7 = reader.ReadByte();
            if (hasfield7 == 1)
                field7 = reader.ReadByte();
            hasfield8 = reader.ReadByte();
            if (hasfield8 == 1)
                field8 = reader.ReadUInt32();
            field9 = reader.ReadByte();
            field10 = reader.ReadByte();
            hasfield11 = reader.ReadByte();
            if (hasfield11 == 1)
                pKTNewNpc_1_2 = reader.Read<PKTNewNpc_1_2>();
            hasfield12 = reader.ReadByte();
            if (hasfield12 == 1)
                field12 = reader.ReadByte();
            field13 = reader.ReadByte();
            hasfield14 = reader.ReadByte();
            if (hasfield14 == 1)
                field14 = reader.ReadUInt64();
            NpcType = reader.ReadUInt32();
            hasfield16 = reader.ReadByte();
            if (hasfield16 == 1)
                field16 = reader.ReadByte();
            hasfield17 = reader.ReadByte();
            if (hasfield17 == 1)
                field17 = reader.ReadUInt32();
            hasfield18 = reader.ReadByte();
            if (hasfield18 == 1)
                field18 = reader.ReadUInt16();
            hasfield19 = reader.ReadByte();
            if (hasfield19 == 1)
                field19 = reader.ReadUInt32();
            hasfield20 = reader.ReadByte();
            if (hasfield20 == 1)
                field20 = reader.ReadList<UInt64>();
            field21 = reader.ReadByte();
            field22 = reader.ReadUInt16();
            pKTNewNpc_1_4_1s = reader.ReadList<PKTNewNpc_1_4_1>();
            hasfield24 = reader.ReadByte();
            if (hasfield24 == 1)
                field24 = reader.ReadUInt16();
            field25 = reader.ReadUInt32();
            NpcId = reader.ReadUInt64();
            hasfield27 = reader.ReadByte();
            if (hasfield27 == 1)
                field27 = reader.ReadUInt32();
            field28 = reader.ReadByte();
            hasfield29 = reader.ReadByte();
            if (hasfield29 == 1)
                field29 = reader.ReadByte();
            hasfield30 = reader.ReadByte();
            if (hasfield30 == 1)
                field30 = reader.ReadList<Byte[]>(12);
            field31 = reader.ReadUInt64();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
        }
        public UInt16 field0;
        public Byte field1;
        public Byte hasfield2;
        public Byte field2;
        public Byte hasfield3;
        public UInt32 field3;
        public StatPair statPair;
        public Byte hasfield5;
        public Byte field5;
        public Byte hasfield6;
        public Byte field6;
        public Byte hasfield7;
        public Byte field7;
        public Byte hasfield8;
        public UInt32 field8;
        public Byte field9;
        public Byte field10;
        public Byte hasfield11;
        public PKTNewNpc_1_2 pKTNewNpc_1_2;
        public Byte hasfield12;
        public Byte field12;
        public Byte field13;
        public Byte hasfield14;
        public UInt64 field14;
        public UInt32 NpcType;
        public Byte hasfield16;
        public Byte field16;
        public Byte hasfield17;
        public UInt32 field17;
        public Byte hasfield18;
        public UInt16 field18;
        public Byte hasfield19;
        public UInt32 field19;
        public Byte hasfield20;
        public List<UInt64> field20;
        public Byte field21;
        public UInt16 field22;
        public List<PKTNewNpc_1_4_1> pKTNewNpc_1_4_1s;
        public Byte hasfield24;
        public UInt16 field24;
        public UInt32 field25;
        public UInt64 NpcId;
        public Byte hasfield27;
        public UInt32 field27;
        public Byte field28;
        public Byte hasfield29;
        public Byte field29;
        public Byte hasfield30;
        public List<Byte[]> field30;
        public UInt64 field31;
        public List<StatusEffectData> statusEffectDatas;
    }
}
