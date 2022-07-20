using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class NpcStruct
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
            b_13 = reader.ReadByte();
            if (b_13 == 1)
                u32_3 = reader.ReadUInt32();
            b_21 = reader.ReadByte();
            if (b_21 == 1)
                u64_1 = reader.ReadUInt64();
            b_25 = reader.ReadByte();
            if (b_25 == 1)
                b_26 = reader.ReadByte();
            b_27 = reader.ReadByte();
            if (b_27 == 1)
                u32_5 = reader.ReadUInt32();
            b_28 = reader.ReadByte();
            if (b_28 == 1)
                subPKTNewNpc66 = reader.Read<subPKTNewNpc66>();
            b_29 = reader.ReadByte();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            b_30 = reader.ReadByte();
            if (b_30 == 1)
                u16_3 = reader.ReadUInt16();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                u32_0 = reader.ReadUInt32();
            b_4 = reader.ReadByte();
            if (b_4 == 1)
                u32_1 = reader.ReadUInt32();
            u32_2 = reader.ReadUInt32();
            NpcType = reader.ReadUInt32();
            b_5 = reader.ReadByte();
            if (b_5 == 1)
                b_6 = reader.ReadByte();
            b_7 = reader.ReadByte();
            b_8 = reader.ReadByte();
            if (b_8 == 1)
                u16_0 = reader.ReadUInt16();
            b_9 = reader.ReadByte();
            b_10 = reader.ReadByte();
            if (b_10 == 1)
                b_11 = reader.ReadByte();
            b_12 = reader.ReadByte();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            b_14 = reader.ReadByte();
            if (b_14 == 1)
                b_15 = reader.ReadByte();
            b_16 = reader.ReadByte();
            if (b_16 == 1)
                b_17 = reader.ReadByte();
            u16_1 = reader.ReadUInt16();
            u16_2 = reader.ReadUInt16();
            b_18 = reader.ReadByte();
            if (b_18 == 1)
                bytearraylist = reader.ReadList<Byte[]>(12);
            NpcId = reader.ReadUInt64();
            b_19 = reader.ReadByte();
            if (b_19 == 1)
                b_20 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            statPair = reader.Read<StatPair>();
            b_22 = reader.ReadByte();
            if (b_22 == 1)
                u32_4 = reader.ReadUInt32();
            b_23 = reader.ReadByte();
            if (b_23 == 1)
                u64list = reader.ReadList<UInt64>();
            b_24 = reader.ReadByte();
        }
    }
}
