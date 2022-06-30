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
            b_6 = reader.ReadByte();
            u32list = reader.ReadList<UInt32>();
            u32_4 = reader.ReadUInt32();
            u32_6 = reader.ReadUInt32();
            //subPKTNewNpc29s = reader.ReadList<subPKTNewNpc29>();
            b_12 = reader.ReadByte();
            u32_7 = reader.ReadUInt32();
            u32_8 = reader.ReadUInt32();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                bytearray_1 = reader.ReadBytes(12);
            b_3 = reader.ReadByte();
            b_4 = reader.ReadByte();
            itemInfos = reader.ReadList<ItemInfo>();
            u16_0 = reader.ReadUInt16();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            u16_1 = reader.ReadUInt16();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            b_5 = reader.ReadByte();
            u16_2 = reader.ReadUInt16();
            Level = reader.ReadUInt16();
            b_7 = reader.ReadByte();
            u32_0 = reader.ReadUInt32();
            u32_1 = reader.ReadUInt32();
            skillRunes = reader.Read<SkillRunes>();
            u32_2 = reader.ReadUInt32();
            u64_0 = reader.ReadUInt64();
            u32_3 = reader.ReadUInt32();
            b_8 = reader.ReadByte();
            b_9 = reader.ReadByte();
            ClassId = reader.ReadUInt16();
            bytearray_0 = reader.ReadBytes(25);
            statPair = reader.Read<StatPair>();
            b_10 = reader.ReadByte();
            //blist = reader.ReadList<Byte>();
            u64_1 = reader.ReadUInt64();
            GearLevel = reader.ReadUInt32();
            EquippedItems = reader.ReadList<ItemInfo>();
            bytearray_2 = reader.ReadBytes(5);
            u32_5 = reader.ReadUInt32();
            PlayerId = reader.ReadUInt64();
            u16_3 = reader.ReadUInt16();
            b_11 = reader.ReadByte();
        }
    }
}
