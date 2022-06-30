using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class ProjectileInfo
    {
        public void KoreaDecode(BitReader reader)
        {
            u64_0 = reader.ReadUInt64();
            OwnerId = reader.ReadUInt64();
            u32_4 = reader.ReadUInt32();
            u64_2 = reader.ReadUInt64();
            //b_4 = reader.ReadByte();
            bytearray = reader.ReadBytes(6);
            //u64_3 = reader.ReadUInt64();
            SkillLevel = reader.ReadByte();
            SkillId = reader.ReadUInt32();
            u16_1 = reader.ReadUInt16();
            u32_0 = reader.ReadUInt32();
            Tripods = reader.ReadBytes(3);
            u16_0 = reader.ReadUInt16();
            u32_1 = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            if (b_0 == 1)
                u64_1 = reader.ReadUInt64();
            b_1 = reader.ReadByte();
            if (b_1 == 1)
                u64list = reader.ReadList<UInt64>();
            b_2 = reader.ReadByte();
            if (b_2 == 1)
                u32_2 = reader.ReadUInt32();
            b_3 = reader.ReadByte();
            u32_3 = reader.ReadUInt32();
            ProjectileId = reader.ReadUInt64();
            SkillEffect = reader.ReadUInt32();
        }
    }
}
