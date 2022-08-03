using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void SteamDecode(BitReader reader)
        {
            PlayerId = reader.ReadUInt64();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            u16_1 = reader.ReadUInt16();
            Name = reader.ReadString();
            b_7 = reader.ReadByte();
            u32_7 = reader.ReadUInt32();
            b_11 = reader.ReadByte();
            b_12 = reader.ReadByte();
            u16_3 = reader.ReadUInt16();
            u32_8 = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            PartyId = reader.ReadUInt64();
            ClassId = reader.ReadUInt16();
            u32_0 = reader.ReadUInt32();
            u16_0 = reader.ReadUInt16();
            GearLevel = reader.ReadUInt32();
            skillRunes = reader.Read<SkillRunes>();
            Level = reader.ReadUInt16();
            bytearray_2 = reader.ReadBytes(5);
            b_1 = reader.ReadByte();
            u32_1 = reader.ReadUInt32();
            b_2 = reader.ReadByte();
            u16_2 = reader.ReadUInt16();
            u32_2 = reader.ReadUInt32();
            u32_3 = reader.ReadUInt32();
            u64_0 = reader.ReadUInt64();
            u32_4 = reader.ReadUInt32();
            b_3 = reader.ReadByte();
            statPair = reader.Read<StatPair>();
            itemInfos = reader.ReadList<ItemInfo>();
            b_4 = reader.ReadByte();
            u32_5 = reader.ReadUInt32();
            u32list_0 = reader.ReadList<UInt32>();
            str_0 = reader.ReadString();
            b_5 = reader.ReadByte();
            bytearray_0 = reader.ReadBytes(25);
            EquippedItems = reader.ReadList<ItemInfo>();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            b_6 = reader.ReadByte();
            u32_6 = reader.ReadUInt32();
            b_8 = reader.ReadByte();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            b_9 = reader.ReadByte();
            if (b_9 == 1)
                bytearray_1 = reader.ReadBytes(12);
            b_10 = reader.ReadByte();
        }
    }
}
