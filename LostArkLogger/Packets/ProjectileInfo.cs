using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class ProjectileInfo
    {
        public ProjectileInfo(BitReader reader)
        {
            SkillLevel = reader.ReadByte();
            field1 = reader.ReadByte();
            field2 = reader.ReadUInt64();
            field3 = reader.ReadUInt16();
            field4 = reader.ReadUInt16();
            hasfield5 = reader.ReadByte();
            if (hasfield5 == 1)
                field5 = reader.ReadUInt32();
            field6 = reader.ReadUInt64();
            field7 = reader.ReadUInt32();
            hasfield8 = reader.ReadByte();
            if (hasfield8 == 1)
                field8 = reader.ReadList<UInt64>();
            field9 = reader.ReadUInt32();
            field10 = reader.ReadUInt32();
            field11 = reader.ReadByte();
            field12 = reader.ReadUInt32();
            OwnerId = reader.ReadUInt64();
            SkillEffect = reader.ReadUInt32();
            Tripods = reader.ReadBytes(3);
            SkillId = reader.ReadUInt32();
            ProjectileId = reader.ReadUInt64();
            field18 = reader.ReadUInt64();
            field19 = reader.ReadBytes(6);
        }
        public Byte SkillLevel;
        public Byte field1;
        public UInt64 field2;
        public UInt16 field3;
        public UInt16 field4;
        public Byte hasfield5;
        public UInt32 field5;
        public UInt64 field6;
        public UInt32 field7;
        public Byte hasfield8;
        public List<UInt64> field8;
        public UInt32 field9;
        public UInt32 field10;
        public Byte field11;
        public UInt32 field12;
        public UInt64 OwnerId;
        public UInt32 SkillEffect;
        public Byte[] Tripods;
        public UInt32 SkillId;
        public UInt64 ProjectileId;
        public UInt64 field18;
        public Byte[] field19;
    }
}
