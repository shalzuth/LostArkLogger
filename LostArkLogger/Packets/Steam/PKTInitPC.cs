using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitPC
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            ClassId = reader.ReadUInt16();
            b_8 = reader.ReadByte();
            u32_9 = reader.ReadUInt32();
            b_17 = reader.ReadByte();
            u32_12 = reader.ReadUInt32();
            bytearraylist_1 = reader.ReadList<Byte[]>(17);
            b_20 = reader.ReadByte();
            u64_4 = reader.ReadUInt64();
            u32_0 = reader.ReadUInt32();
            b_1 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                u32_1 = reader.ReadUInt32();
            b_3 = reader.ReadByte();
            GearLevel = reader.ReadUInt32();
            u32_2 = reader.ReadUInt32();
            u32_3 = reader.ReadUInt32();
            Name = reader.ReadString();
            b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            bytearray_3 = reader.ReadBytes(25);
            u32_4 = reader.ReadUInt32();
            u16_0 = reader.ReadUInt16();
            u64_1 = reader.ReadUInt64();
            u32_5 = reader.ReadUInt32();
            bytearray_2 = reader.ReadBytes(35);
            b_7 = reader.ReadByte();
            statPair = reader.Read<StatPair>();
            u64_2 = reader.ReadUInt64();
            b_9 = reader.ReadByte();
            b_10 = reader.ReadByte();
            u32_6 = reader.ReadUInt32();
            blist_0 = reader.ReadList<Byte>();
            u32_7 = reader.ReadUInt32();
            bytearray_1 = reader.ReadBytes(0);
            Level = reader.ReadUInt16();
            bytearray_0 = reader.ReadBytes(110);
            b_11 = reader.ReadByte();
            b_12 = reader.ReadByte();
            u32_8 = reader.ReadUInt32();
            u16_1 = reader.ReadUInt16();
            b_13 = reader.ReadByte();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            PlayerId = reader.ReadUInt64();
            b_14 = reader.ReadByte();
            b_15 = reader.ReadByte();
            u32_10 = reader.ReadUInt32();
            u16list_0 = reader.ReadList<UInt16>();
            b_16 = reader.ReadByte();
            u16_2 = reader.ReadUInt16();
            b_18 = reader.ReadByte();
            u64_3 = reader.ReadUInt64();
            b_19 = reader.ReadByte();
            u16_3 = reader.ReadUInt16();
            bytearraylist_0 = reader.ReadList<Byte[]>(30);
            u32_11 = reader.ReadUInt32();
            u16_4 = reader.ReadUInt16();
        }
    }
}
