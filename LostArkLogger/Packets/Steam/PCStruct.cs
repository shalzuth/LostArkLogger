using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            u32_0 = reader.ReadUInt32();
            ClassId = reader.ReadUInt16();
            EquippedItems = reader.ReadList<ItemInfo>();
            b_12 = reader.ReadByte();
            str_0 = reader.ReadString();
            u16_3 = reader.ReadUInt16();
            Name = reader.ReadString();
            u32_7 = reader.ReadUInt32();
            u32_8 = reader.ReadUInt32();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                bytearray_1 = reader.ReadBytes(12);
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            u32_1 = reader.ReadUInt32();
            u16_0 = reader.ReadUInt16();
            b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
            b_6 = reader.ReadByte();
            b_7 = reader.ReadByte();
            u32_2 = reader.ReadUInt32();
            b_8 = reader.ReadByte();
            u32_3 = reader.ReadUInt32();
            b_9 = reader.ReadByte();
            PartyId = reader.ReadUInt64();
            b_10 = reader.ReadByte();
            bytearray_0 = reader.ReadBytes(25);
            itemInfos = reader.ReadList<ItemInfo>();
            u64_0 = reader.ReadUInt64();
            u32_4 = reader.ReadUInt32();
            Level = reader.ReadUInt16();
            skillRunes = reader.Read<SkillRunes>();
            u32_5 = reader.ReadUInt32();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            u16_1 = reader.ReadUInt16();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            b_11 = reader.ReadByte();
            bytearray_2 = reader.ReadBytes(5);
            statPair = reader.Read<StatPair>();
            u32_6 = reader.ReadUInt32();
            GearLevel = reader.ReadUInt32();
            u32list_0 = reader.ReadList<UInt32>();
            u16_2 = reader.ReadUInt16();
        }
    }
}
