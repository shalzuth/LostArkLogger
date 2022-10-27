using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void SteamDecode(BitReader reader)
        {
            u32_0 = reader.ReadUInt32();
            u32_1 = reader.ReadUInt32();
            bytearray_2 = reader.ReadBytes(5);
            u16_4 = reader.ReadUInt16();
            b_9 = reader.ReadByte();
            b_10 = reader.ReadByte();
            u32_8 = reader.ReadUInt32();
            u32_9 = reader.ReadUInt32();
            b_11 = reader.ReadByte();
            b_12 = reader.ReadByte();
            u32_2 = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            u32_3 = reader.ReadUInt32();
            statPair = reader.Read<StatPair>();
            u16_0 = reader.ReadUInt16();
            b_2 = reader.ReadByte();
            EquippedItems = reader.ReadList<ItemInfo>();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                bytearray_1 = reader.ReadBytes(12);
            b_4 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            str_0 = reader.ReadString();
            u64_1 = reader.ReadUInt64();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            u32_4 = reader.ReadUInt32();
            u16_1 = reader.ReadUInt16();
            u16_2 = reader.ReadUInt16();
            u16_3 = reader.ReadUInt16();
            itemInfos = reader.ReadList<ItemInfo>();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            u32list_0 = reader.ReadList<UInt32>();
            u32_5 = reader.ReadUInt32();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            u32_6 = reader.ReadUInt32();
            b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            u32_7 = reader.ReadUInt32();
            b_7 = reader.ReadByte();
            skillRunes = reader.Read<SkillRunes>();
            b_8 = reader.ReadByte();
            u16_5 = reader.ReadUInt16();
            str_1 = reader.ReadString();
            bytearray_0 = reader.ReadBytes(25);
            u64_2 = reader.ReadUInt64();
        }
    }
}
