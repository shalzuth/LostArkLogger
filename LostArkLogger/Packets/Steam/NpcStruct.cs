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
            if (b_0 == 1)
                u64list_0 = reader.ReadList<UInt64>();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            b_23 = reader.ReadByte();
            if (b_23 == 1)
                u64_0 = reader.ReadUInt64();
            statPair = reader.Read<StatPair>();
            b_26 = reader.ReadByte();
            b_27 = reader.ReadByte();
            if (b_27 == 1)
                b_28 = reader.ReadByte();
            b_29 = reader.ReadByte();
            if (b_29 == 1)
                u32_5 = reader.ReadUInt32();
            u64_1 = reader.ReadUInt64();
            b_30 = reader.ReadByte();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                u32_0 = reader.ReadUInt32();
            b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                u16_1 = reader.ReadUInt16();
            b_4 = reader.ReadByte();
            if (b_4 == 1)
                b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            b_7 = reader.ReadByte();
            if (b_7 == 1)
                b_8 = reader.ReadByte();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            NpcType = reader.ReadUInt32();
            b_9 = reader.ReadByte();
            u16_2 = reader.ReadUInt16();
            b_10 = reader.ReadByte();
            if (b_10 == 1)
                u32_1 = reader.ReadUInt32();
            b_11 = reader.ReadByte();
            if (b_11 == 1)
                b_12 = reader.ReadByte();
            u32_2 = reader.ReadUInt32();
            b_13 = reader.ReadByte();
            b_14 = reader.ReadByte();
            if (b_14 == 1)
                u16_3 = reader.ReadUInt16();
            b_15 = reader.ReadByte();
            if (b_15 == 1)
                b_16 = reader.ReadByte();
            b_17 = reader.ReadByte();
            if (b_17 == 1)
                b_18 = reader.ReadByte();
            b_19 = reader.ReadByte();
            if (b_19 == 1)
                u32_3 = reader.ReadUInt32();
            b_20 = reader.ReadByte();
            if (b_20 == 1)
                u32_4 = reader.ReadUInt32();
            b_21 = reader.ReadByte();
            if (b_21 == 1)
                b_22 = reader.ReadByte();
            NpcId = reader.ReadUInt64();
            b_24 = reader.ReadByte();
            if (b_24 == 1)
                bytearraylist_0 = reader.ReadList<Byte[]>(12);
            b_25 = reader.ReadByte();
            if (b_25 == 1)
                subPKTNewNpc66 = reader.Read<subPKTNewNpc66>();
        }
    }
}
