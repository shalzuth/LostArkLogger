using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void KoreaDecode(BitReader reader)
        {
            PlayerId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            u32_3 = reader.ReadUInt32();
            skillRunes = reader.Read<SkillRunes>();
            GearLevel = reader.ReadUInt32();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            u32_7 = reader.ReadUInt32();
            b_12 = reader.ReadByte();
            u32_8 = reader.ReadUInt32();
            Name = reader.ReadString();
            b_1 = reader.ReadByte();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            u32_0 = reader.ReadUInt32();
            u32_1 = reader.ReadUInt32();
            Level = reader.ReadUInt16();
            b_2 = reader.ReadByte();
            u32_2 = reader.ReadUInt32();
            b_3 = reader.ReadByte();
            b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            if (b_6 == 1)
                bytearray_1 = reader.ReadBytes(12);
            u32_4 = reader.ReadUInt32();
            u16_0 = reader.ReadUInt16();
            u64 = reader.ReadUInt64();
            b_7 = reader.ReadByte();
            u32_5 = reader.ReadUInt32();
            itemInfos = reader.ReadList<ItemInfo>();
            statPair = reader.Read<StatPair>();
            u16_1 = reader.ReadUInt16();
            PartyId = reader.ReadUInt64();
            b_8 = reader.ReadByte();
            u16_2 = reader.ReadUInt16();
            blist = reader.ReadList<Byte>();
            ClassId = reader.ReadUInt16();
            u32_6 = reader.ReadUInt32();
            bytearray_2 = reader.ReadBytes(5);
            b_9 = reader.ReadByte();
            u16_3 = reader.ReadUInt16();
            b_10 = reader.ReadByte();
            b_11 = reader.ReadByte();
            u32list = reader.ReadList<UInt32>();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            bytearray_0 = reader.ReadBytes(25);
            EquippedItems = reader.ReadList<ItemInfo>();
        }
    }
}
