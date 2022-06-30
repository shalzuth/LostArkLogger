using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void SteamDecode(BitReader reader)
        {
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            u64_0 = reader.ReadUInt64();
            u32_3 = reader.ReadUInt32();
            u32_5 = reader.ReadUInt32();
            u16_3 = reader.ReadUInt16();
            GearLevel = reader.ReadUInt32();
            bytearray_0 = reader.ReadBytes(25);
            u32_8 = reader.ReadUInt32();
            b_12 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            u32_0 = reader.ReadUInt32();
            u32_1 = reader.ReadUInt32();
            statPair = reader.Read<StatPair>();
            b_2 = reader.ReadByte();
            str = reader.ReadString();
            u16_0 = reader.ReadUInt16();
            u64_1 = reader.ReadUInt64();
            u32_2 = reader.ReadUInt32();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            u16_1 = reader.ReadUInt16();
            u32_4 = reader.ReadUInt32();
            b_3 = reader.ReadByte();
            u32list = reader.ReadList<UInt32>();
            b_4 = reader.ReadByte();
            u16_2 = reader.ReadUInt16();
            b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            u32_6 = reader.ReadUInt32();
            skillRunes = reader.Read<SkillRunes>();
            b_7 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
            ClassId = reader.ReadUInt16();
            Level = reader.ReadUInt16();
            EquippedItems = reader.ReadList<ItemInfo>();
            b_8 = reader.ReadByte();
            b_9 = reader.ReadByte();
            b_10 = reader.ReadByte();
            bytearray_2 = reader.ReadBytes(5);
            b_11 = reader.ReadByte();
            if (b_11 == 1)
                bytearray_1 = reader.ReadBytes(12);
            u32_7 = reader.ReadUInt32();
            Name = reader.ReadString();
        }
    }
}
