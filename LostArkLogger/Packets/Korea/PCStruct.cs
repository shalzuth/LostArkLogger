using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void KoreaDecode(BitReader reader)
        {
            u16_0 = reader.ReadUInt16();
            b_0 = reader.ReadByte();
            b_3 = reader.ReadByte();
            b_4 = reader.ReadByte();
            u32_7 = reader.ReadUInt32();
            u16_3 = reader.ReadUInt16();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            b_11 = reader.ReadByte();
            u32_8 = reader.ReadUInt32();
            b_12 = reader.ReadByte();
            Level = reader.ReadUInt16();
            Name = reader.ReadString();
            statPair = reader.Read<StatPair>();
            u16_1 = reader.ReadUInt16();
            skillRunes = reader.Read<SkillRunes>();
            bytearray_2 = reader.ReadBytes(5);
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
            u32_0 = reader.ReadUInt32();
            u16_2 = reader.ReadUInt16();
            u32_1 = reader.ReadUInt32();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            u32_2 = reader.ReadUInt32();
            u32_3 = reader.ReadUInt32();
            ClassId = reader.ReadUInt16();
            u16list_0 = reader.ReadList<UInt16>();
            itemInfos = reader.ReadList<ItemInfo>();
            u64_0 = reader.ReadUInt64();
            PartyId = reader.ReadUInt64();
            bytearray_0 = reader.ReadBytes(25);
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            u32_4 = reader.ReadUInt32();
            u32_5 = reader.ReadUInt32();
            b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            b_7 = reader.ReadByte();
            if (b_7 == 1)
                bytearray_1 = reader.ReadBytes(12);
            u32list_0 = reader.ReadList<UInt32>();
            b_8 = reader.ReadByte();
            u32_6 = reader.ReadUInt32();
            EquippedItems = reader.ReadList<ItemInfo>();
            GearLevel = reader.ReadUInt32();
            b_9 = reader.ReadByte();
            b_10 = reader.ReadByte();
        }
    }
}
