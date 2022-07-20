using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class NpcStruct
    {
        public NpcStruct(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public UInt64 NpcId;
        public UInt32 NpcType;
        public subPKTNewNpc66 subPKTNewNpc66;
        public List<StatusEffectData> statusEffectDatas;
        public List<subPKTInitPC29> subPKTInitPC29s;
        public List<UInt64> u64list_0;
        public List<Byte[]> bytearraylist_0;
        public StatPair statPair;
        public UInt64 u64_0;
        public UInt64 u64_1;
        public UInt32 u32_0;
        public UInt32 u32_1;
        public UInt32 u32_2;
        public UInt32 u32_3;
        public UInt32 u32_4;
        public UInt32 u32_5;
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
        public Byte b_13;
        public Byte b_14;
        public Byte b_15;
        public Byte b_16;
        public Byte b_17;
        public Byte b_18;
        public Byte b_19;
        public Byte b_20;
        public Byte b_21;
        public Byte b_22;
        public Byte b_23;
        public Byte b_24;
        public Byte b_25;
        public Byte b_26;
        public Byte b_27;
        public Byte b_28;
        public Byte b_29;
        public Byte b_30;
    }
}
