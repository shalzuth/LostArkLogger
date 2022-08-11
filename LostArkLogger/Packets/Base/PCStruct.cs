using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public PCStruct(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public String Name;
        public List<ItemInfo> EquippedItems;
        public UInt64 PartyId;
        public UInt64 PlayerId;
        public UInt32 GearLevel;
        public UInt16 ClassId;
        public UInt16 Level;
        public String str_0;
        public List<UInt16> u16list_0;
        public List<StatusEffectData> statusEffectDatas;
        public List<subPKTInitPC29> subPKTInitPC29s;
        public List<ItemInfo> itemInfos;
        public List<UInt32> u32list_0;
        public subPKTNewNpc5 subPKTNewNpc5;
        public StatPair statPair;
        public SkillRunes skillRunes;
        public Byte[] bytearray_0;
        public Byte[] bytearray_1;
        public UInt64 u64_0;
        public Byte[] bytearray_2;
        public UInt32 u32_0;
        public UInt32 u32_1;
        public UInt32 u32_2;
        public UInt32 u32_3;
        public UInt32 u32_4;
        public UInt32 u32_5;
        public UInt32 u32_6;
        public UInt32 u32_7;
        public UInt32 u32_8;
        public UInt16 u16_0;
        public UInt16 u16_1;
        public UInt16 u16_2;
        public UInt16 u16_3;
        public Byte b_0;
        public Byte b_1;
        public Byte b_2;
        public Byte b_3;
        public Byte b_4;
        public Byte b_5;
        public Byte b_6;
        public Byte b_7;
        public Byte b_8;
        public Byte b_9;
        public Byte b_10;
        public Byte b_11;
        public Byte b_12;
    }
}
