using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class ProjectileInfo
    {
        public ProjectileInfo(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public UInt64 OwnerId;
        public UInt64 ProjectileId;
        public UInt32 SkillEffect;
        public UInt32 SkillId;
        public Byte[] Tripods;
        public Byte SkillLevel;
        public List<UInt64> u64list_0;
        public UInt64 u64_0;
        public UInt64 u64_1;
        public UInt64 u64_2;
        public UInt64 u64_3;
        public Byte[] bytearray_0;
        public UInt32 u32_0;
        public UInt32 u32_1;
        public UInt32 u32_2;
        public UInt32 u32_3;
        public UInt32 u32_4;
        public UInt16 u16_0;
        public UInt16 u16_1;
        public Byte b_0;
        public Byte b_1;
        public Byte b_2;
        public Byte b_3;
        public Byte b_4;
    }
}
