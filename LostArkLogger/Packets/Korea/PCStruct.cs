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
            PartyId = reader.ReadUInt64();
            statPair = reader.Read<StatPair>();
            u32_8 = reader.ReadUInt32();
            Name = reader.ReadString();
            b_12 = reader.ReadByte();
            u32list_0 = reader.ReadList<UInt32>();
            PlayerId = reader.ReadUInt64();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            bytearray_2 = reader.ReadBytes(5);
            b_4 = reader.ReadByte();
            Level = reader.ReadUInt16();
            EquippedItems = reader.ReadList<ItemInfo>();
            u32_0 = reader.ReadUInt32();
            u32_1 = reader.ReadUInt32();
            GearLevel = reader.ReadUInt32();
            itemInfos = reader.ReadList<ItemInfo>();
            u64_0 = reader.ReadUInt64();
            bytearray_0 = reader.ReadBytes(25);
            b_5 = reader.ReadByte();
            u32_2 = reader.ReadUInt32();
            u16_1 = reader.ReadUInt16();
            blist_0 = reader.ReadList<Byte>();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            skillRunes = reader.Read<SkillRunes>();
            u32_3 = reader.ReadUInt32();
            b_6 = reader.ReadByte();
            u32_4 = reader.ReadUInt32();
            b_7 = reader.ReadByte();
            u32_5 = reader.ReadUInt32();
            u16_2 = reader.ReadUInt16();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            u32_6 = reader.ReadUInt32();
            b_8 = reader.ReadByte();
            if (b_8 == 1)
                bytearray_1 = reader.ReadBytes(12);
            u32_7 = reader.ReadUInt32();
            u16_3 = reader.ReadUInt16();
            ClassId = reader.ReadUInt16();
            b_9 = reader.ReadByte();
            b_10 = reader.ReadByte();
            b_11 = reader.ReadByte();
        }
    }
}
