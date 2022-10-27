using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class NpcStruct
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                u16_0 = reader.ReadUInt16();
            NpcId = reader.ReadUInt64();
            b_12 = reader.ReadByte();
            u32_4 = reader.ReadUInt32();
            NpcType = reader.ReadUInt32();
            statPair = reader.Read<StatPair>();
            b_27 = reader.ReadByte();
            b_28 = reader.ReadByte();
            b_29 = reader.ReadByte();
            if (b_29 == 1)
                u32_5 = reader.ReadUInt32();
            b_30 = reader.ReadByte();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            if (b_5 == 1)
                u16_1 = reader.ReadUInt16();
            b_6 = reader.ReadByte();
            if (b_6 == 1)
                u64list_0 = reader.ReadList<UInt64>();
            b_7 = reader.ReadByte();
            if (b_7 == 1)
                u32_0 = reader.ReadUInt32();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            b_8 = reader.ReadByte();
            b_9 = reader.ReadByte();
            if (b_9 == 1)
                b_10 = reader.ReadByte();
            u16_2 = reader.ReadUInt16();
            b_11 = reader.ReadByte();
            if (b_11 == 1)
                bytearraylist_0 = reader.ReadList<Byte[]>(12);
            u16_3 = reader.ReadUInt16();
            b_13 = reader.ReadByte();
            if (b_13 == 1)
                u32_1 = reader.ReadUInt32();
            b_14 = reader.ReadByte();
            b_15 = reader.ReadByte();
            if (b_15 == 1)
                u32_2 = reader.ReadUInt32();
            b_16 = reader.ReadByte();
            if (b_16 == 1)
                b_17 = reader.ReadByte();
            b_18 = reader.ReadByte();
            if (b_18 == 1)
                b_19 = reader.ReadByte();
            b_20 = reader.ReadByte();
            if (b_20 == 1)
                u64_0 = reader.ReadUInt64();
            b_21 = reader.ReadByte();
            if (b_21 == 1)
                u32_3 = reader.ReadUInt32();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            b_22 = reader.ReadByte();
            if (b_22 == 1)
                b_23 = reader.ReadByte();
            b_24 = reader.ReadByte();
            if (b_24 == 1)
                b_25 = reader.ReadByte();
            b_26 = reader.ReadByte();
            if (b_26 == 1)
                subPKTNewNpc66 = reader.Read<subPKTNewNpc66>();
            u64_1 = reader.ReadUInt64();
        }
    }
}
