using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void KoreaDecode(BitReader reader)
        {
            u32_0 = reader.ReadUInt32();
            Level = reader.ReadUInt16();
            b_6 = reader.ReadByte();
            b_8 = reader.ReadByte();
            b_10 = reader.ReadByte();
            blist_0 = reader.ReadList<Byte>();
            b_12 = reader.ReadByte();
            u32_6 = reader.ReadUInt32();
            u32_7 = reader.ReadUInt32();
            u32_8 = reader.ReadUInt32();
            Name = reader.ReadString();
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            u32_1 = reader.ReadUInt32();
            b_2 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            b_3 = reader.ReadByte();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            u32list_0 = reader.ReadList<UInt32>();
            bytearray_0 = reader.ReadBytes(25);
            u32_2 = reader.ReadUInt32();
            PlayerId = reader.ReadUInt64();
            u32_3 = reader.ReadUInt32();
            skillRunes = reader.Read<SkillRunes>();
            u16_0 = reader.ReadUInt16();
            b_7 = reader.ReadByte();
            if (b_7 == 1)
                bytearray_1 = reader.ReadBytes(12);
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            u32_4 = reader.ReadUInt32();
            statPair = reader.Read<StatPair>();
            ClassId = reader.ReadUInt16();
            u16_1 = reader.ReadUInt16();
            b_9 = reader.ReadByte();
            bytearray_2 = reader.ReadBytes(5);
            u16_2 = reader.ReadUInt16();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            u16_3 = reader.ReadUInt16();
            PartyId = reader.ReadUInt64();
            EquippedItems = reader.ReadList<ItemInfo>();
            u64_0 = reader.ReadUInt64();
            u32_5 = reader.ReadUInt32();
            b_11 = reader.ReadByte();
            GearLevel = reader.ReadUInt32();
        }
    }
}
