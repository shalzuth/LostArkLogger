using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void SteamDecode(BitReader reader)
        {
            pKTNewNpc_1_2_2 = reader.Read<PKTNewNpc_1_2_2>();
            hasfield1 = reader.ReadByte();
            if (hasfield1 == 1)
                field1 = reader.ReadBytes(12);
            field2 = reader.ReadByte();
            field3 = reader.ReadByte();
            field4 = reader.ReadByte();
            field5 = reader.ReadUInt32();
            field6 = reader.ReadByte();
            field7 = reader.ReadUInt32();
            field8 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            ClassId = reader.ReadUInt16();
            skillRunes = reader.Read<SkillRunes>();
            GearLevel = reader.ReadUInt32();
            field13 = reader.ReadUInt64();
            field14 = reader.ReadUInt64();
            field15 = reader.ReadUInt32();
            field16 = reader.ReadList<UInt32>();
            Name = reader.ReadString();
            field18 = reader.ReadUInt32();
            field19 = reader.ReadUInt16();
            field20 = reader.ReadUInt32();
            field21 = reader.ReadByte();
            EquippedItems = reader.ReadList<ItemInfo>();
            field23 = reader.ReadBytes(5);
            field24 = reader.ReadUInt32();
            field25 = reader.ReadByte();
            field26 = reader.ReadUInt32();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            field28 = reader.ReadUInt16();
            field29 = reader.ReadByte();
            Guild = reader.ReadString();
            field31 = reader.ReadByte();
            field32 = reader.ReadByte();
            field33 = reader.ReadBytes(25);
            field34 = reader.ReadUInt16();
            PlayerId = reader.ReadUInt64();
            field36 = reader.ReadByte();
            Level = reader.ReadUInt16();
            field38 = reader.ReadUInt16();
            field39 = reader.ReadUInt32();
            statPair = reader.Read<StatPair>();
            field41 = reader.ReadByte();
            field42 = reader.ReadUInt32();
            pKTNewNpc_1_4_1s = reader.ReadList<PKTNewNpc_1_4_1>();
        }
    }
}
