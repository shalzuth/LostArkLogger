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
                u32_0 = reader.ReadUInt32();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            NpcType = reader.ReadUInt32();
            b_20 = reader.ReadByte();
            if (b_20 == 1)
                u32_2 = reader.ReadUInt32();
            b_24 = reader.ReadByte();
            if (b_24 == 1)
                u32_5 = reader.ReadUInt32();
            b_25 = reader.ReadByte();
            b_26 = reader.ReadByte();
            if (b_26 == 1)
                b_27 = reader.ReadByte();
            statPair = reader.Read<StatPair>();
            b_28 = reader.ReadByte();
            if (b_28 == 1)
                b_29 = reader.ReadByte();
            b_30 = reader.ReadByte();
            if (b_30 == 1)
                subPKTNewNpc66 = reader.Read<subPKTNewNpc66>();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                u16_0 = reader.ReadUInt16();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                b_3 = reader.ReadByte();
            b_4 = reader.ReadByte();
            if (b_4 == 1)
                u64_0 = reader.ReadUInt64();
            b_5 = reader.ReadByte();
            if (b_5 == 1)
                b_6 = reader.ReadByte();
            b_7 = reader.ReadByte();
            if (b_7 == 1)
                blist_0 = reader.ReadList<Byte>();
            b_8 = reader.ReadByte();
            u16_1 = reader.ReadUInt16();
            b_9 = reader.ReadByte();
            if (b_9 == 1)
                b_10 = reader.ReadByte();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            u32_1 = reader.ReadUInt32();
            NpcId = reader.ReadUInt64();
            u16_2 = reader.ReadUInt16();
            b_11 = reader.ReadByte();
            if (b_11 == 1)
                u16_3 = reader.ReadUInt16();
            b_12 = reader.ReadByte();
            if (b_12 == 1)
                bytearraylist_0 = reader.ReadList<Byte[]>(12);
            b_13 = reader.ReadByte();
            if (b_13 == 1)
                b_14 = reader.ReadByte();
            b_15 = reader.ReadByte();
            if (b_15 == 1)
                b_16 = reader.ReadByte();
            b_17 = reader.ReadByte();
            b_18 = reader.ReadByte();
            u64_1 = reader.ReadUInt64();
            b_19 = reader.ReadByte();
            b_21 = reader.ReadByte();
            if (b_21 == 1)
                u32_3 = reader.ReadUInt32();
            b_22 = reader.ReadByte();
            b_23 = reader.ReadByte();
            if (b_23 == 1)
                u32_4 = reader.ReadUInt32();
        }
    }
}
