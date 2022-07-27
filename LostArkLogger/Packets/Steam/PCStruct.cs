using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void SteamDecode(BitReader reader)
        {
            bytearray_0 = reader.ReadBytes(25);
            u64_0 = reader.ReadUInt64();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            b_7 = reader.ReadByte();
            u32_6 = reader.ReadUInt32();
            b_12 = reader.ReadByte();
            u32list_0 = reader.ReadList<UInt32>();
            GearLevel = reader.ReadUInt32();
            u32_8 = reader.ReadUInt32();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            statPair = reader.Read<StatPair>();
            u32_0 = reader.ReadUInt32();
            Level = reader.ReadUInt16();
            u16_0 = reader.ReadUInt16();
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            u32_1 = reader.ReadUInt32();
            EquippedItems = reader.ReadList<ItemInfo>();
            b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            b_4 = reader.ReadByte();
            bytearray_2 = reader.ReadBytes(5);
            u32_2 = reader.ReadUInt32();
            b_5 = reader.ReadByte();
            if (b_5 == 1)
                bytearray_1 = reader.ReadBytes(12);
            u32_3 = reader.ReadUInt32();
            str_0 = reader.ReadString();
            skillRunes = reader.Read<SkillRunes>();
            PartyId = reader.ReadUInt64();
            b_6 = reader.ReadByte();
            u32_4 = reader.ReadUInt32();
            Name = reader.ReadString();
            itemInfos = reader.ReadList<ItemInfo>();
            u16_1 = reader.ReadUInt16();
            b_8 = reader.ReadByte();
            b_9 = reader.ReadByte();
            ClassId = reader.ReadUInt16();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            PlayerId = reader.ReadUInt64();
            u32_5 = reader.ReadUInt32();
            b_10 = reader.ReadByte();
            u16_2 = reader.ReadUInt16();
            u16_3 = reader.ReadUInt16();
            u32_7 = reader.ReadUInt32();
            b_11 = reader.ReadByte();
        }
    }
}
