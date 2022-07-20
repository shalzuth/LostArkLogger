using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void SteamDecode(BitReader reader)
        {
            u32list = reader.ReadList<UInt32>();
            b_0 = reader.ReadByte();
            b_3 = reader.ReadByte();
            b_7 = reader.ReadByte();
            Name = reader.ReadString();
            PlayerId = reader.ReadUInt64();
            bytearray_2 = reader.ReadBytes(5);
            u32_8 = reader.ReadUInt32();
            u64 = reader.ReadUInt64();
            b_12 = reader.ReadByte();
            str = reader.ReadString();
            Level = reader.ReadUInt16();
            skillRunes = reader.Read<SkillRunes>();
            u32_0 = reader.ReadUInt32();
            u32_1 = reader.ReadUInt32();
            u32_2 = reader.ReadUInt32();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            EquippedItems = reader.ReadList<ItemInfo>();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            u32_3 = reader.ReadUInt32();
            ClassId = reader.ReadUInt16();
            PartyId = reader.ReadUInt64();
            u16_0 = reader.ReadUInt16();
            b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            bytearray_0 = reader.ReadBytes(25);
            b_6 = reader.ReadByte();
            u32_4 = reader.ReadUInt32();
            u32_5 = reader.ReadUInt32();
            b_8 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            b_9 = reader.ReadByte();
            if (b_9 == 1)
                bytearray_1 = reader.ReadBytes(12);
            u16_1 = reader.ReadUInt16();
            statPair = reader.Read<StatPair>();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            GearLevel = reader.ReadUInt32();
            u32_6 = reader.ReadUInt32();
            b_10 = reader.ReadByte();
            b_11 = reader.ReadByte();
            u16_2 = reader.ReadUInt16();
            u16_3 = reader.ReadUInt16();
            u32_7 = reader.ReadUInt32();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
        }
    }
}
