using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public void SteamDecode(BitReader reader)
        {
            str_0 = reader.ReadString(); //guild name
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            b_0 = reader.ReadByte();
            ClassId = reader.ReadUInt16();
            PlayerId = reader.ReadUInt64();
            u32_0 = reader.ReadUInt32();
            skillRunes = reader.Read<SkillRunes>();
            subPKTNewNpc5 = reader.Read<subPKTNewNpc5>();
            b_1 = reader.ReadByte();
            u32_1 = reader.ReadUInt32();
            EquippedItems = reader.ReadList<ItemInfo>();
            b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            u32_7 = reader.ReadUInt32();
            b_7 = reader.ReadByte();
            b_8 = reader.ReadByte();
            b_9 = reader.ReadByte();
            b_10 = reader.ReadByte();
            Level = reader.ReadUInt16();
            Name = reader.ReadString();
            u16_0 = reader.ReadUInt16();
            u32_2 = reader.ReadUInt32();
            u32_3 = reader.ReadUInt32();
            PartyId = reader.ReadUInt64();
            u16_1 = reader.ReadUInt16();
            u32_4 = reader.ReadUInt32();
            itemInfos = reader.ReadList<ItemInfo>();
            bytearray_1 = reader.ReadBytes(5);
            u32list_0 = reader.ReadList<UInt32>();
            u16_2 = reader.ReadUInt16();
            u16_3 = reader.ReadUInt16();
            u32_5 = reader.ReadUInt32();
            u64_0 = reader.ReadUInt64();
            statPair = reader.Read<StatPair>();
            bytearray_2 = reader.ReadBytes(5);
            bytearray_0 = reader.ReadBytes(25);
            u32_6 = reader.ReadUInt32();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            GearLevel = reader.ReadUInt32();
            b_11 = reader.ReadByte();
        }
    }
}
