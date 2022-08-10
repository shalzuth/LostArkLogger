using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void SteamDecode(BitReader reader)
        {
            PlayerId = reader.ReadUInt64();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            b_1 = reader.ReadByte();
            u16_1 = reader.ReadUInt16();
            u32_6 = reader.ReadUInt32();
            GearLevel = reader.ReadUInt32();
            b_10 = reader.ReadByte();
            b_11 = reader.ReadByte();
            b_12 = reader.ReadByte();
            u32_8 = reader.ReadUInt32();
            u32_0 = reader.ReadUInt32();
            EquippedItems = reader.ReadList<ItemInfo>();
            bytearray_2 = reader.ReadBytes(5);
            statPair = reader.Read<StatPair>();
            bytearray_0 = reader.ReadBytes(25);
            b_0 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            skillRunes = reader.Read<SkillRunes>();
            PartyId = reader.ReadUInt64();
            u32_1 = reader.ReadUInt32();
            u32_2 = reader.ReadUInt32();
            u32_3 = reader.ReadUInt32();
            ClassId = reader.ReadUInt16();
            b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            u32_4 = reader.ReadUInt32();
            u32_5 = reader.ReadUInt32();
            itemInfos = reader.ReadList<ItemInfo>();
            Level = reader.ReadUInt16();
            u16_2 = reader.ReadUInt16();
            b_6 = reader.ReadByte();
            u16_3 = reader.ReadUInt16();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            u32list_0 = reader.ReadList<UInt32>();
            b_7 = reader.ReadByte();
            if (b_7 == 1)
                bytearray_1 = reader.ReadBytes(12);
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            u64_0 = reader.ReadUInt64();
            b_8 = reader.ReadByte();
            Name = reader.ReadString();
            str_0 = reader.ReadString();
            u32_7 = reader.ReadUInt32();
            b_9 = reader.ReadByte();
        }
    }
}
