using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitPC
    {
        public PKTInitPC(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public String Name;
        public UInt64 PlayerId;
        public UInt32 GearLevel;
        public UInt16 ClassId;
        public UInt16 Level;
        public List<StatusEffectData> statusEffectDatas;
        public List<subPKTInitPC29> subPKTInitPC29s;
        public List<UInt16> u16list_0;
        public List<Byte[]> bytearraylist_0;
        public List<Byte[]> bytearraylist_1;
        public List<Byte> blist_0;
        public StatPair statPair;
        public Byte[] bytearray_0;
        public Byte[] bytearray_1;
        public Byte[] bytearray_2;
        public Byte[] bytearray_3;
        public UInt64 u64_0;
        public UInt64 u64_1;
        public UInt64 u64_2;
        public UInt64 u64_3;
        public UInt32 u32_0;
        public UInt32 u32_1;
        public UInt32 u32_2;
        public UInt32 u32_3;
        public UInt32 u32_4;
        public UInt32 u32_5;
        public UInt32 u32_6;
        public UInt32 u32_7;
        public UInt32 u32_8;
        public UInt32 u32_9;
        public UInt32 u32_10;
        public UInt32 u32_11;
        public UInt32 u32_12;
        public UInt16 u16_0;
        public UInt16 u16_1;
        public UInt16 u16_2;
        public UInt16 u16_3;
        public UInt16 u16_4;
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
    }
}
