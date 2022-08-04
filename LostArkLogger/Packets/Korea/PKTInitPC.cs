using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitPC
    {
        public void KoreaDecode(BitReader reader)
        {
            Name = reader.ReadString();
            b_0 = reader.ReadByte();
            b_6 = reader.ReadByte();
            u16_2 = reader.ReadUInt16();
            ClassId = reader.ReadUInt16();
            u64_2 = reader.ReadUInt64();
            u16_4 = reader.ReadUInt16();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            u64_3 = reader.ReadUInt64();
            u16list_0 = reader.ReadList<UInt16>();
            u32_0 = reader.ReadUInt32();
            b_1 = reader.ReadByte();
            b_2 = reader.ReadByte();
            b_3 = reader.ReadByte();
            u32_1 = reader.ReadUInt32();
            u32_2 = reader.ReadUInt32();
            b_4 = reader.ReadByte();
            if (b_4 == 1)
                u32_3 = reader.ReadUInt32();
            b_5 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            u16_1 = reader.ReadUInt16();
            b_7 = reader.ReadByte();
            bytearray_1 = reader.ReadBytes(8);
            Level = reader.ReadUInt16();
            bytearray_0 = reader.ReadBytes(102);
            blist_0 = reader.ReadList<Byte>();
            b_8 = reader.ReadByte();
            b_9 = reader.ReadByte();
            GearLevel = reader.ReadUInt32();
            bytearray_2 = reader.ReadBytes(35);
            b_10 = reader.ReadByte();
            u32_4 = reader.ReadUInt32();
            statPair = reader.Read<StatPair>();
            u32_5 = reader.ReadUInt32();
            u32_6 = reader.ReadUInt32();
            b_11 = reader.ReadByte();
            b_12 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            subPKTInitPC29s = reader.ReadList<subPKTInitPC29>();
            b_13 = reader.ReadByte();
            u16_3 = reader.ReadUInt16();
            u32_7 = reader.ReadUInt32();
            b_14 = reader.ReadByte();
            u32_8 = reader.ReadUInt32();
            b_15 = reader.ReadByte();
            u32_9 = reader.ReadUInt32();
            bytearraylist_0 = reader.ReadList<Byte[]>(30);
            u32_10 = reader.ReadUInt32();
            b_16 = reader.ReadByte();
            u64_1 = reader.ReadUInt64();
            u32_11 = reader.ReadUInt32();
            bytearray_3 = reader.ReadBytes(25);
            b_17 = reader.ReadByte();
            b_18 = reader.ReadByte();
            u32_12 = reader.ReadUInt32();
            b_19 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
        }
    }
}
