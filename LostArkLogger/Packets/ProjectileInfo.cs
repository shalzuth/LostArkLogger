using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class ProjectileInfo
    {
        public ProjectileInfo(BitReader reader)
        {
            field0 = reader.ReadBytes(6);
            field1 = reader.ReadByte();
            hasfield2 = reader.ReadByte();
            if (hasfield2 == 1)
                field2 = reader.ReadUInt32();
            field3 = reader.ReadByte();
            field4 = reader.ReadUInt32();
            field5 = reader.ReadUInt32();
            field6 = reader.ReadUInt64();
            Tripods = reader.ReadBytes(3);
            SkillId = reader.ReadUInt32();
            field9 = reader.ReadUInt32();
            ProjectileId = reader.ReadUInt64();
            field11 = reader.ReadUInt16();
            hasfield12 = reader.ReadByte();
            if (hasfield12 == 1)
                field12 = reader.ReadList<UInt64>();
            field13 = reader.ReadUInt16();
            OwnerId = reader.ReadUInt64();
            field15 = reader.ReadUInt32();
            SkillLevel = reader.ReadByte();
            SkillEffect = reader.ReadUInt32();
            field18 = reader.ReadUInt64();
            field19 = reader.ReadUInt64();
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
