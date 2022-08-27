using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitPC
    {
        public void SteamDecode(BitReader reader)
        {
            u32_0 = reader.ReadUInt32();
            bytearray_3 = reader.ReadBytes(25);
            b_1 = reader.ReadByte();
            u32_4 = reader.ReadUInt32();
            b_10 = reader.ReadByte();
            b_15 = reader.ReadByte();
            b_19 = reader.ReadByte();
            u32_11 = reader.ReadUInt32();
            b_20 = reader.ReadByte();
            u64_3 = reader.ReadUInt64();
            bytearraylist_1 = reader.ReadList<Byte[]>(17);
            u16_0 = reader.ReadUInt16();
            u16_1 = reader.ReadUInt16();
            b_0 = reader.ReadByte();
            u32_1 = reader.ReadUInt32();
            ClassId = reader.ReadUInt16();
            GearLevel = reader.ReadUInt32();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            u32_2 = reader.ReadUInt32();
            u16_2 = reader.ReadUInt16();
            u32_3 = reader.ReadUInt32();
            u64_0 = reader.ReadUInt64();
            b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            u16_3 = reader.ReadUInt16();
            u64_1 = reader.ReadUInt64();
            bytearray_2 = reader.ReadBytes(35);
            blist_0 = reader.ReadList<Byte>();
            b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            b_7 = reader.ReadByte();
            u32_5 = reader.ReadUInt32();
            b_8 = reader.ReadByte();
            u16_4 = reader.ReadUInt16();
            Name = reader.ReadString();
            u32_6 = reader.ReadUInt32();
            b_9 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
            b_11 = reader.ReadByte();
            b_12 = reader.ReadByte();
            b_13 = reader.ReadByte();
            if (b_13 == 1)
                u32_7 = reader.ReadUInt32();
            u32_8 = reader.ReadUInt32();
            b_14 = reader.ReadByte();
            u32_9 = reader.ReadUInt32();
            bytearray_1 = reader.ReadBytes(16);
            Level = reader.ReadUInt16();
            bytearray_0 = reader.ReadBytes(94);
            bytearraylist_0 = reader.ReadList<Byte[]>(30);
            u16list_0 = reader.ReadList<UInt16>();
            statPair = reader.Read<StatPair>();
            b_16 = reader.ReadByte();
            u64_2 = reader.ReadUInt64();
            u32_10 = reader.ReadUInt32();
            b_17 = reader.ReadByte();
            b_18 = reader.ReadByte();
        }
    }
}
