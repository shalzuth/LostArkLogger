using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitPC
    {
        public void KoreaDecode(BitReader reader)
        {
            bytearray_3 = reader.ReadBytes(25);
            b_0 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            b_8 = reader.ReadByte();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            b_16 = reader.ReadByte();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            u64_3 = reader.ReadUInt64();
            b_18 = reader.ReadByte();
            b_19 = reader.ReadByte();
            u32_0 = reader.ReadUInt32();
            GearLevel = reader.ReadUInt32();
            b_1 = reader.ReadByte();
            ClassId = reader.ReadUInt16();
            u32_1 = reader.ReadUInt32();
            b_2 = reader.ReadByte();
            u32_2 = reader.ReadUInt32();
            b_3 = reader.ReadByte();
            statPair = reader.Read<StatPair>();
            u16list = reader.ReadList<UInt16>();
            u16_1 = reader.ReadUInt16();
            b_4 = reader.ReadByte();
            b_5 = reader.ReadByte();
            blist = reader.ReadList<Byte>();
            u64_0 = reader.ReadUInt64();
            b_6 = reader.ReadByte();
            Name = reader.ReadString();
            u16_2 = reader.ReadUInt16();
            u32_3 = reader.ReadUInt32();
            b_7 = reader.ReadByte();
            b_9 = reader.ReadByte();
            bytearray_1 = reader.ReadBytes(8);
            Level = reader.ReadUInt16();
            bytearray_0 = reader.ReadBytes(102);
            b_10 = reader.ReadByte();
            b_11 = reader.ReadByte();
            if (b_11 == 1)
                u32_4 = reader.ReadUInt32();
            b_12 = reader.ReadByte();
            u32_5 = reader.ReadUInt32();
            u16_3 = reader.ReadUInt16();
            b_13 = reader.ReadByte();
            u32_6 = reader.ReadUInt32();
            PlayerId = reader.ReadUInt64();
            u32_7 = reader.ReadUInt32();
            u32_8 = reader.ReadUInt32();
            u16_4 = reader.ReadUInt16();
            u64_1 = reader.ReadUInt64();
            u32_9 = reader.ReadUInt32();
            u64_2 = reader.ReadUInt64();
            b_14 = reader.ReadByte();
            b_15 = reader.ReadByte();
            u32_10 = reader.ReadUInt32();
            u32_11 = reader.ReadUInt32();
            bytearraylist_0 = reader.ReadList<Byte[]>(30);
            b_17 = reader.ReadByte();
            u32_12 = reader.ReadUInt32();
            bytearray_2 = reader.ReadBytes(35);
        }
    }
}
