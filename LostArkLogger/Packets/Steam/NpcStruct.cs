using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class NpcStruct
    {
        public void SteamDecode(BitReader reader)
        {
            u16_0 = reader.ReadUInt16();
            b_0 = reader.ReadByte();
            b_12 = reader.ReadByte();
            if (b_12 == 1)
                b_13 = reader.ReadByte();
            b_21 = reader.ReadByte();
            if (b_21 == 1)
                u32_4 = reader.ReadUInt32();
            statPair = reader.Read<StatPair>();
            b_23 = reader.ReadByte();
            if (b_23 == 1)
                b_24 = reader.ReadByte();
            b_25 = reader.ReadByte();
            if (b_25 == 1)
                b_26 = reader.ReadByte();
            b_27 = reader.ReadByte();
            if (b_27 == 1)
                b_28 = reader.ReadByte();
            b_29 = reader.ReadByte();
            if (b_29 == 1)
                u32_5 = reader.ReadUInt32();
            b_30 = reader.ReadByte();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                subPKTNewNpc66 = reader.Read<subPKTNewNpc66>();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            if (b_6 == 1)
                u64_0 = reader.ReadUInt64();
            NpcType = reader.ReadUInt32();
            b_7 = reader.ReadByte();
            if (b_7 == 1)
                b_8 = reader.ReadByte();
            b_9 = reader.ReadByte();
            if (b_9 == 1)
                u32_0 = reader.ReadUInt32();
            b_10 = reader.ReadByte();
            if (b_10 == 1)
                u16_1 = reader.ReadUInt16();
            b_11 = reader.ReadByte();
            if (b_11 == 1)
                u32_1 = reader.ReadUInt32();
            b_14 = reader.ReadByte();
            if (b_14 == 1)
                u64list = reader.ReadList<UInt64>();
            b_15 = reader.ReadByte();
            u16_2 = reader.ReadUInt16();
            subPKTNewNpc29s = reader.ReadList<subPKTNewNpc29>();
            b_16 = reader.ReadByte();
            if (b_16 == 1)
                u16_3 = reader.ReadUInt16();
            u32_2 = reader.ReadUInt32();
            NpcId = reader.ReadUInt64();
            b_17 = reader.ReadByte();
            if (b_17 == 1)
                u32_3 = reader.ReadUInt32();
            b_18 = reader.ReadByte();
            b_19 = reader.ReadByte();
            if (b_19 == 1)
                b_20 = reader.ReadByte();
            b_22 = reader.ReadByte();
            if (b_22 == 1)
                bytearraylist = reader.ReadList<Byte[]>(12);
            u64_1 = reader.ReadUInt64();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
        }
    }
}
