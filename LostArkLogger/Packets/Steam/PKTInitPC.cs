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
            u32_2 = reader.ReadUInt32();
            u32_4 = reader.ReadUInt32();
            u32_7 = reader.ReadUInt32();
            u32_10 = reader.ReadUInt32();
            bytearray_1 = reader.ReadBytes(4);
            Level = reader.ReadUInt16();
            bytearray_0 = reader.ReadBytes(106);
            b_20 = reader.ReadByte();
            u32_11 = reader.ReadUInt32();
            bytearray_3 = reader.ReadBytes(25);
            bytearraylist_0 = reader.ReadList<Byte[]>(30);
            u16_0 = reader.ReadUInt16();
            u32_0 = reader.ReadUInt32();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            u32_1 = reader.ReadUInt32();
            b_3 = reader.ReadByte();
            statPair = reader.Read<StatPair>();
            b_4 = reader.ReadByte();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            u16_1 = reader.ReadUInt16();
            b_5 = reader.ReadByte();
            b_6 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            u32_3 = reader.ReadUInt32();
            b_7 = reader.ReadByte();
            b_8 = reader.ReadByte();
            b_9 = reader.ReadByte();
            bytearraylist_1 = reader.ReadList<Byte[]>(17);
            b_10 = reader.ReadByte();
            u64_1 = reader.ReadUInt64();
            b_11 = reader.ReadByte();
            Name = reader.ReadString();
            b_12 = reader.ReadByte();
            bytearray_2 = reader.ReadBytes(35);
            u32_5 = reader.ReadUInt32();
            b_13 = reader.ReadByte();
            u32_6 = reader.ReadUInt32();
            u16_2 = reader.ReadUInt16();
            u64_2 = reader.ReadUInt64();
            u16list_0 = reader.ReadList<UInt16>();
            b_14 = reader.ReadByte();
            ClassId = reader.ReadUInt16();
            b_15 = reader.ReadByte();
            b_16 = reader.ReadByte();
            if (b_16 == 1)
                u32_8 = reader.ReadUInt32();
            u64_3 = reader.ReadUInt64();
            u32_9 = reader.ReadUInt32();
            blist_0 = reader.ReadList<Byte>();
            GearLevel = reader.ReadUInt32();
            b_17 = reader.ReadByte();
            u16_3 = reader.ReadUInt16();
            u16_4 = reader.ReadUInt16();
            b_18 = reader.ReadByte();
            b_19 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
        }
    }
}
