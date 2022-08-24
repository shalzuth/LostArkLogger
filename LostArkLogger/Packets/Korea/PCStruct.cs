using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void KoreaDecode(BitReader reader)
        {
            Name = reader.ReadString();
            b_0 = reader.ReadByte();
            EquippedItems = reader.ReadList<ItemInfo>();
            b_8 = reader.ReadByte();
            b_11 = reader.ReadByte();
            u32list_0 = reader.ReadList<UInt32>();
            bytearray_2 = reader.ReadBytes(5);
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            u16_3 = reader.ReadUInt16();
            b_12 = reader.ReadByte();
            b_1 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            b_2 = reader.ReadByte();
            u32_0 = reader.ReadUInt32();
            u32_1 = reader.ReadUInt32();
            b_3 = reader.ReadByte();
            u16_1 = reader.ReadUInt16();
            u64_0 = reader.ReadUInt64();
            b_4 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            Level = reader.ReadUInt16();
            u32_2 = reader.ReadUInt32();
            b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            u16list_0 = reader.ReadList<UInt16>();
            GearLevel = reader.ReadUInt32();
            PartyId = reader.ReadUInt64();
            b_7 = reader.ReadByte();
            if (b_7 == 1)
                bytearray_1 = reader.ReadBytes(12);
            u32_3 = reader.ReadUInt32();
            u32_4 = reader.ReadUInt32();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            b_9 = reader.ReadByte();
            ClassId = reader.ReadUInt16();
            b_10 = reader.ReadByte();
            u32_5 = reader.ReadUInt32();
            u16_2 = reader.ReadUInt16();
            statPair = reader.Read<StatPair>();
            skillRunes = reader.Read<SkillRunes>();
            PlayerId = reader.ReadUInt64();
            u32_6 = reader.ReadUInt32();
            u32_7 = reader.ReadUInt32();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            u32_8 = reader.ReadUInt32();
            bytearray_0 = reader.ReadBytes(25);
        }
    }
}
