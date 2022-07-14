using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class ProjectileInfo
    {
        public void KoreaDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                u64list = reader.ReadList<UInt64>();
            ProjectileId = reader.ReadUInt64();
            u32_3 = reader.ReadUInt32();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                u64_2 = reader.ReadUInt64();
            u64_3 = reader.ReadUInt64();
            b_3 = reader.ReadByte();
            Tripods = reader.ReadBytes(3);
            OwnerId = reader.ReadUInt64();
            b_4 = reader.ReadByte();
            if (b_4 == 1)
                u32_4 = reader.ReadUInt32();
            SkillEffect = reader.ReadUInt32();
            u64_0 = reader.ReadUInt64();
            u16_0 = reader.ReadUInt16();
            SkillId = reader.ReadUInt32();
            u32_0 = reader.ReadUInt32();
            bytearray = reader.ReadBytes(6);
            b_1 = reader.ReadByte();
            u16_1 = reader.ReadUInt16();
            u32_1 = reader.ReadUInt32();
            u32_2 = reader.ReadUInt32();
            u64_1 = reader.ReadUInt64();
            SkillLevel = reader.ReadByte();
        }
    }
}
