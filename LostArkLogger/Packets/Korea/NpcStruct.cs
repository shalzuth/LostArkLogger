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
                bytearraylist_0 = reader.ReadList<Byte[]>(12);
            b_12 = reader.ReadByte();
            b_22 = reader.ReadByte();
            if (b_22 == 1)
                u32_4 = reader.ReadUInt32();
            b_25 = reader.ReadByte();
            if (b_25 == 1)
                b_26 = reader.ReadByte();
            b_27 = reader.ReadByte();
            u16_3 = reader.ReadUInt16();
            b_28 = reader.ReadByte();
            if (b_28 == 1)
                b_29 = reader.ReadByte();
            statPair = reader.Read<StatPair>();
            b_30 = reader.ReadByte();
            b_3 = reader.ReadByte();
            b_4 = reader.ReadByte();
            if (b_4 == 1)
                u32_0 = reader.ReadUInt32();
            b_5 = reader.ReadByte();
            if (b_5 == 1)
                b_6 = reader.ReadByte();
            NpcId = reader.ReadUInt64();
            b_7 = reader.ReadByte();
            if (b_7 == 1)
                subPKTNewNpc66 = reader.Read<subPKTNewNpc66>();
            b_8 = reader.ReadByte();
            if (b_8 == 1)
                u16_0 = reader.ReadUInt16();
            b_9 = reader.ReadByte();
            NpcType = reader.ReadUInt32();
            u32_1 = reader.ReadUInt32();
            b_10 = reader.ReadByte();
            if (b_10 == 1)
                b_11 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            b_13 = reader.ReadByte();
            if (b_13 == 1)
                b_14 = reader.ReadByte();
            u16_1 = reader.ReadUInt16();
            b_15 = reader.ReadByte();
            if (b_15 == 1)
                u64_1 = reader.ReadUInt64();
            b_16 = reader.ReadByte();
            if (b_16 == 1)
                u64list_0 = reader.ReadList<UInt64>();
            b_17 = reader.ReadByte();
            if (b_17 == 1)
                u32_2 = reader.ReadUInt32();
            b_18 = reader.ReadByte();
            if (b_18 == 1)
                u32_3 = reader.ReadUInt32();
            b_19 = reader.ReadByte();
            b_20 = reader.ReadByte();
            if (b_20 == 1)
                b_21 = reader.ReadByte();
            b_23 = reader.ReadByte();
            if (b_23 == 1)
                u16_2 = reader.ReadUInt16();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            b_24 = reader.ReadByte();
            if (b_24 == 1)
                u32_5 = reader.ReadUInt32();
        }
    }
}
