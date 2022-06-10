using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void SteamDecode(BitReader reader)
        {
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                bytearray_1 = reader.ReadBytes(12);
            b_1 = reader.ReadByte();
            b_5 = reader.ReadByte();
            b_9 = reader.ReadByte();
            u32_7 = reader.ReadUInt32();
            b_11 = reader.ReadByte();
            u32_8 = reader.ReadUInt32();
            b_12 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            ClassId = reader.ReadUInt16();
            skillRunes = reader.Read<SkillRunes>();
            GearLevel = reader.ReadUInt32();
            u64_0 = reader.ReadUInt64();
            u64_1 = reader.ReadUInt64();
            u32_0 = reader.ReadUInt32();
            u32list = reader.ReadList<UInt32>();
            Name = reader.ReadString();
            u32_1 = reader.ReadUInt32();
            u16_0 = reader.ReadUInt16();
            u32_2 = reader.ReadUInt32();
            b_2 = reader.ReadByte();
            EquippedItems = reader.ReadList<ItemInfo>();
            bytearray_2 = reader.ReadBytes(5);
            u32_3 = reader.ReadUInt32();
            b_3 = reader.ReadByte();
            u32_4 = reader.ReadUInt32();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            u16_1 = reader.ReadUInt16();
            b_4 = reader.ReadByte();
            str = reader.ReadString();
            b_6 = reader.ReadByte();
            b_7 = reader.ReadByte();
            bytearray_0 = reader.ReadBytes(25);
            u16_2 = reader.ReadUInt16();
            PlayerId = reader.ReadUInt64();
            b_8 = reader.ReadByte();
            Level = reader.ReadUInt16();
            u16_3 = reader.ReadUInt16();
            u32_5 = reader.ReadUInt32();
            statPair = reader.Read<StatPair>();
            b_10 = reader.ReadByte();
            u32_6 = reader.ReadUInt32();
            subPKTNewNpc29s = reader.ReadList<subPKTNewNpc29>();
        }
    }
}
