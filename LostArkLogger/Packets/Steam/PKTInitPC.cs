using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitPC
    {
        public void SteamDecode(BitReader reader)
        {
            u64_0 = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            u32_3 = reader.ReadUInt32();
            u32_8 = reader.ReadUInt32();
            bytearraylist_0 = reader.ReadList<Byte[]>(30);
            b_16 = reader.ReadByte();
            bytearray_2 = reader.ReadBytes(35);
            u16_4 = reader.ReadUInt16();
            b_20 = reader.ReadByte();
            ClassId = reader.ReadUInt16();
            u16list_0 = reader.ReadList<UInt16>();
            b_1 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            b_2 = reader.ReadByte();
            u32_0 = reader.ReadUInt32();
            b_3 = reader.ReadByte();
            u32_1 = reader.ReadUInt32();
            u32_2 = reader.ReadUInt32();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            statPair = reader.Read<StatPair>();
            b_4 = reader.ReadByte();
            u32_4 = reader.ReadUInt32();
            Name = reader.ReadString();
            u64_1 = reader.ReadUInt64();
            b_5 = reader.ReadByte();
            if (b_5 == 1)
                u32_5 = reader.ReadUInt32();
            b_6 = reader.ReadByte();
            u32_6 = reader.ReadUInt32();
            GearLevel = reader.ReadUInt32();
            b_7 = reader.ReadByte();
            u32_7 = reader.ReadUInt32();
            u64_2 = reader.ReadUInt64();
            bytearray_3 = reader.ReadBytes(25);
            u64_3 = reader.ReadUInt64();
            b_8 = reader.ReadByte();
            b_9 = reader.ReadByte();
            u64_4 = reader.ReadUInt64();
            b_10 = reader.ReadByte();
            bytearraylist_1 = reader.ReadList<Byte[]>(17);
            blist_0 = reader.ReadList<Byte>();
            b_11 = reader.ReadByte();
            u32_9 = reader.ReadUInt32();
            u32_10 = reader.ReadUInt32();
            b_12 = reader.ReadByte();
            bytearray_1 = reader.ReadBytes(16);
            Level = reader.ReadUInt16();
            bytearray_0 = reader.ReadBytes(94);
            b_13 = reader.ReadByte();
            u32_11 = reader.ReadUInt32();
            b_14 = reader.ReadByte();
            u16_1 = reader.ReadUInt16();
            u16_2 = reader.ReadUInt16();
            b_15 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            b_17 = reader.ReadByte();
            b_18 = reader.ReadByte();
            u32_12 = reader.ReadUInt32();
            u16_3 = reader.ReadUInt16();
            b_19 = reader.ReadByte();
        }
    }
}
