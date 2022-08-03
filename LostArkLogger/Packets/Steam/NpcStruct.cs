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
                b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                u32_0 = reader.ReadUInt32();
            b_15 = reader.ReadByte();
            if (b_15 == 1)
                u32_2 = reader.ReadUInt32();
            b_26 = reader.ReadByte();
            u32_4 = reader.ReadUInt32();
            b_28 = reader.ReadByte();
            b_29 = reader.ReadByte();
            if (b_29 == 1)
                u32_5 = reader.ReadUInt32();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            b_30 = reader.ReadByte();
            if (b_30 == 1)
                u64list_0 = reader.ReadList<UInt64>();
            NpcType = reader.ReadUInt32();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                u16_0 = reader.ReadUInt16();
            b_4 = reader.ReadByte();
            if (b_4 == 1)
                b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            if (b_6 == 1)
                subPKTNewNpc66 = reader.Read<subPKTNewNpc66>();
            b_7 = reader.ReadByte();
            b_8 = reader.ReadByte();
            if (b_8 == 1)
                b_9 = reader.ReadByte();
            b_10 = reader.ReadByte();
            if (b_10 == 1)
                u16_1 = reader.ReadUInt16();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            b_11 = reader.ReadByte();
            if (b_11 == 1)
                b_12 = reader.ReadByte();
            b_13 = reader.ReadByte();
            if (b_13 == 1)
                u64_0 = reader.ReadUInt64();
            b_14 = reader.ReadByte();
            if (b_14 == 1)
                u32_1 = reader.ReadUInt32();
            b_16 = reader.ReadByte();
            if (b_16 == 1)
                b_17 = reader.ReadByte();
            b_18 = reader.ReadByte();
            if (b_18 == 1)
                b_19 = reader.ReadByte();
            b_20 = reader.ReadByte();
            u16_2 = reader.ReadUInt16();
            NpcId = reader.ReadUInt64();
            b_21 = reader.ReadByte();
            if (b_21 == 1)
                u32_3 = reader.ReadUInt32();
            u16_3 = reader.ReadUInt16();
            b_22 = reader.ReadByte();
            b_23 = reader.ReadByte();
            if (b_23 == 1)
                bytearraylist_0 = reader.ReadList<Byte[]>(12);
            b_24 = reader.ReadByte();
            if (b_24 == 1)
                b_25 = reader.ReadByte();
            u64_1 = reader.ReadUInt64();
            b_27 = reader.ReadByte();
            statPair = reader.Read<StatPair>();
        }
    }
}
