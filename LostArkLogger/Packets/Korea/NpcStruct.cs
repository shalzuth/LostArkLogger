using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class NpcStruct
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                b_3 = reader.ReadByte();
            b_11 = reader.ReadByte();
            if (b_11 == 1)
                u64list = reader.ReadList<UInt64>();
            b_20 = reader.ReadByte();
            if (b_20 == 1)
                b_21 = reader.ReadByte();
            subPKTNewNpc29s = reader.ReadList<subPKTNewNpc29>();
            b_24 = reader.ReadByte();
            if (b_24 == 1)
                b_25 = reader.ReadByte();
            b_26 = reader.ReadByte();
            if (b_26 == 1)
                b_27 = reader.ReadByte();
            b_28 = reader.ReadByte();
            if (b_28 == 1)
                u32_5 = reader.ReadUInt32();
            b_29 = reader.ReadByte();
            if (b_29 == 1)
                u16_3 = reader.ReadUInt16();
            b_30 = reader.ReadByte();
            b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            if (b_5 == 1)
                u32_0 = reader.ReadUInt32();
            statPair = reader.Read<StatPair>();
            u16_0 = reader.ReadUInt16();
            b_6 = reader.ReadByte();
            if (b_6 == 1)
                b_7 = reader.ReadByte();
            b_8 = reader.ReadByte();
            if (b_8 == 1)
                u32_1 = reader.ReadUInt32();
            b_9 = reader.ReadByte();
            if (b_9 == 1)
                u16_1 = reader.ReadUInt16();
            b_10 = reader.ReadByte();
            if (b_10 == 1)
                bytearraylist = reader.ReadList<Byte[]>(12);
            u16_2 = reader.ReadUInt16();
            u32_2 = reader.ReadUInt32();
            b_12 = reader.ReadByte();
            b_13 = reader.ReadByte();
            if (b_13 == 1)
                u64_0 = reader.ReadUInt64();
            NpcId = reader.ReadUInt64();
            b_14 = reader.ReadByte();
            if (b_14 == 1)
                u32_3 = reader.ReadUInt32();
            b_15 = reader.ReadByte();
            if (b_15 == 1)
                b_16 = reader.ReadByte();
            b_17 = reader.ReadByte();
            if (b_17 == 1)
                u32_4 = reader.ReadUInt32();
            u64_1 = reader.ReadUInt64();
            b_18 = reader.ReadByte();
            b_19 = reader.ReadByte();
            NpcType = reader.ReadUInt32();
            b_22 = reader.ReadByte();
            if (b_22 == 1)
                subPKTNewNpc66 = reader.Read<subPKTNewNpc66>();
            b_23 = reader.ReadByte();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
        }
    }
}
