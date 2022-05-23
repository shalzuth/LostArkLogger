using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PCStruct
    {
        public PCStruct(BitReader reader)
        {
            field0 = reader.ReadByte();
            field1 = reader.ReadUInt32();
            field2 = reader.ReadByte();
            field3 = reader.ReadUInt64();
            statPair = reader.Read<StatPair>();
            field5 = reader.ReadUInt32();
            field6 = reader.ReadByte();
            hasfield7 = reader.ReadByte();
            if (hasfield7 == 1)
                field7 = reader.ReadBytes(12);
            field8 = reader.ReadList<UInt32>();
            itemInfos = reader.ReadList<ItemInfo>();
            field10 = reader.ReadByte();
            field11 = reader.ReadByte();
            field12 = reader.ReadUInt32();
            pKTNewNpc_1_1_1 = reader.Read<PKTNewNpc_1_1_1>();
            EquippedItems = reader.ReadList<ItemInfo>();
            Guild = reader.ReadString();
            field16 = reader.ReadUInt32();
            field17 = reader.ReadUInt32();
            field18 = reader.ReadUInt32();
            PlayerId = reader.ReadUInt64();
            field20 = reader.ReadBytes(25);
            field21 = reader.ReadUInt16();
            field22 = reader.ReadBytes(5);
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            field24 = reader.ReadByte();
            Name = reader.ReadString();
            field26 = reader.ReadUInt32();
            field27 = reader.ReadByte();
            pKTNewNpc_1_5_1s = reader.ReadList<PKTNewNpc_1_5_1>();
            field29 = reader.ReadByte();
            GearLevel = reader.ReadUInt32();
            field31 = reader.ReadUInt32();
            field32 = reader.ReadUInt64();
            field33 = reader.ReadByte();
            field34 = reader.ReadByte();
            Level = reader.ReadUInt16();
            ClassId = reader.ReadUInt16();
            field37 = reader.ReadUInt16();
            field38 = reader.ReadUInt32();
            field39 = reader.ReadUInt16();
            field40 = reader.ReadByte();
            skillRunes = reader.Read<SkillRunes>();
            field42 = reader.ReadUInt16();
            field43 = reader.ReadByte();
        }
        public Byte field0;
        public UInt32 field1;
        public Byte field2;
        public UInt64 field3;
        public StatPair statPair;
        public UInt32 field5;
        public Byte field6;
        public Byte hasfield7;
        public Byte[] field7;
        public List<UInt32> field8;
        public List<ItemInfo> itemInfos;
        public Byte field10;
        public Byte field11;
        public UInt32 field12;
        public PKTNewNpc_1_1_1 pKTNewNpc_1_1_1;
        public List<ItemInfo> EquippedItems;
        public String Guild;
        public UInt32 field16;
        public UInt32 field17;
        public UInt32 field18;
        public UInt64 PlayerId;
        public Byte[] field20;
        public UInt16 field21;
        public Byte[] field22;
        public List<StatusEffectData> statusEffectDatas;
        public Byte field24;
        public String Name;
        public UInt32 field26;
        public Byte field27;
        public List<PKTNewNpc_1_5_1> pKTNewNpc_1_5_1s;
        public Byte field29;
        public UInt32 GearLevel;
        public UInt32 field31;
        public UInt64 field32;
        public Byte field33;
        public Byte field34;
        public UInt16 Level;
        public UInt16 ClassId;
        public UInt16 field37;
        public UInt32 field38;
        public UInt16 field39;
        public Byte field40;
        public SkillRunes skillRunes;
        public UInt16 field42;
        public Byte field43;
    }
}
