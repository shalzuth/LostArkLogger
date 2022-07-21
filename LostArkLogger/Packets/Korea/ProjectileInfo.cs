using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class ProjectileInfo
    {
        public void KoreaDecode(BitReader reader)
        {
            OwnerId = reader.ReadUInt64();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                u32_0 = reader.ReadUInt32();
            SkillEffect = reader.ReadUInt32();
            u32_2 = reader.ReadUInt32();
            u64_2 = reader.ReadUInt64();
            SkillLevel = reader.ReadByte();
            u32_3 = reader.ReadUInt32();
            bytearray_0 = reader.ReadBytes(6);
            u32_4 = reader.ReadUInt32();
            b_4 = reader.ReadByte();
            if (b_4 == 1)
                u64_3 = reader.ReadUInt64();
            b_1 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            u64_1 = reader.ReadUInt64();
            u16_0 = reader.ReadUInt16();
            b_2 = reader.ReadByte();
            u16_1 = reader.ReadUInt16();
            b_3 = reader.ReadByte();
            if (b_3 == 1)
                u64list_0 = reader.ReadList<UInt64>();
            Tripods = reader.ReadBytes(3);
            SkillId = reader.ReadUInt32();
            ProjectileId = reader.ReadUInt64();
            u32_1 = reader.ReadUInt32();
        }
    }
}
