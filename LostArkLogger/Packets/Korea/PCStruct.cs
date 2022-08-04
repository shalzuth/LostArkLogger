using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            b_6 = reader.ReadByte();
            u32_4 = reader.ReadUInt32();
            u32_6 = reader.ReadUInt32();
            b_12 = reader.ReadByte();
            u32_7 = reader.ReadUInt32();
            bytearray_2 = reader.ReadBytes(5);
            u32_8 = reader.ReadUInt32();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            u32_0 = reader.ReadUInt32();
            b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                bytearray_1 = reader.ReadBytes(12);
            ClassId = reader.ReadUInt16();
            GearLevel = reader.ReadUInt32();
            b_4 = reader.ReadByte();
            skillRunes = reader.Read<SkillRunes>();
            u16_0 = reader.ReadUInt16();
            bytearray_0 = reader.ReadBytes(25);
            b_5 = reader.ReadByte();
            b_7 = reader.ReadByte();
            u32_1 = reader.ReadUInt32();
            u32_2 = reader.ReadUInt32();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            b_8 = reader.ReadByte();
            u32_3 = reader.ReadUInt32();
            statPair = reader.Read<StatPair>();
            EquippedItems = reader.ReadList<ItemInfo>();
            u32list_0 = reader.ReadList<UInt32>();
            Name = reader.ReadString();
            u16_1 = reader.ReadUInt16();
            b_9 = reader.ReadByte();
            u32_5 = reader.ReadUInt32();
            Level = reader.ReadUInt16();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            b_10 = reader.ReadByte();
            PartyId = reader.ReadUInt64();
            u64_0 = reader.ReadUInt64();
            u16_2 = reader.ReadUInt16();
            u16list_0 = reader.ReadList<UInt16>();
            u16_3 = reader.ReadUInt16();
            b_11 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
            itemInfos = reader.ReadList<ItemInfo>();
        }
    }
}
