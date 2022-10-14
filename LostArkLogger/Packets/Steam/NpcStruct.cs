using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class NpcStruct
    {
        public void SteamDecode(BitReader reader)
        {
            NpcId = reader.ReadUInt64();
            u16_0 = reader.ReadUInt16();
            b_10 = reader.ReadByte();
            if (b_10 == 1)
                u32_1 = reader.ReadUInt32();
            b_22 = reader.ReadByte();
            if (b_22 == 1)
                u64list_0 = reader.ReadList<UInt64>();
            b_26 = reader.ReadByte();
            if (b_26 == 1)
                u16_3 = reader.ReadUInt16();
            b_27 = reader.ReadByte();
            if (b_27 == 1)
                u32_4 = reader.ReadUInt32();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            u32_5 = reader.ReadUInt32();
            b_28 = reader.ReadByte();
            if (b_28 == 1)
                b_29 = reader.ReadByte();
            b_30 = reader.ReadByte();
            u16_1 = reader.ReadUInt16();
            b_0 = reader.ReadByte();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                b_3 = reader.ReadByte();
            b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            if (b_5 == 1)
                bytearraylist_0 = reader.ReadList<Byte[]>(12);
            b_6 = reader.ReadByte();
            if (b_6 == 1)
                subPKTNewNpc66 = reader.Read<subPKTNewNpc66>();
            NpcType = reader.ReadUInt32();
            b_7 = reader.ReadByte();
            if (b_7 == 1)
                b_8 = reader.ReadByte();
            b_9 = reader.ReadByte();
            if (b_9 == 1)
                u32_0 = reader.ReadUInt32();
            b_11 = reader.ReadByte();
            statPair = reader.Read<StatPair>();
            b_12 = reader.ReadByte();
            if (b_12 == 1)
                b_13 = reader.ReadByte();
            b_14 = reader.ReadByte();
            if (b_14 == 1)
                b_15 = reader.ReadByte();
            b_16 = reader.ReadByte();
            if (b_16 == 1)
                u64_1 = reader.ReadUInt64();
            b_17 = reader.ReadByte();
            if (b_17 == 1)
                u32_2 = reader.ReadUInt32();
            b_18 = reader.ReadByte();
            b_19 = reader.ReadByte();
            if (b_19 == 1)
                b_20 = reader.ReadByte();
            b_21 = reader.ReadByte();
            if (b_21 == 1)
                u32_3 = reader.ReadUInt32();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            b_23 = reader.ReadByte();
            if (b_23 == 1)
                u16_2 = reader.ReadUInt16();
            u64_0 = reader.ReadUInt64();
            b_24 = reader.ReadByte();
            if (b_24 == 1)
                b_25 = reader.ReadByte();
        }
    }
}
