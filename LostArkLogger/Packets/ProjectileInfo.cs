using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class ProjectileInfo
    {
        public ProjectileInfo(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) SteamDecode(reader);
        }
        public Byte[] field0;
        public Byte field1;
        public Byte hasfield2;
        public UInt32 field2;
        public Byte field3;
        public UInt32 field4;
        public UInt32 field5;
        public UInt64 field6;
        public Byte[] Tripods;
        public UInt32 SkillId;
        public UInt32 field9;
        public UInt64 ProjectileId;
        public UInt16 field11;
        public Byte hasfield12;
        public List<UInt64> field12;
        public UInt16 field13;
        public UInt64 OwnerId;
        public UInt32 field15;
        public Byte SkillLevel;
        public UInt32 SkillEffect;
        public UInt64 field18;
        public UInt64 field19;
    }
}
