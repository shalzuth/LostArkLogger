using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class ProjectileInfo
    {
        public ProjectileInfo(BitReader reader)
        {
            field0 = reader.ReadByte();
            field1 = reader.ReadUInt16();
            OwnerId = reader.ReadUInt64();
            field3 = reader.ReadUInt64();
            field4 = reader.ReadUInt64();
            field5 = reader.ReadUInt32();
            hasfield6 = reader.ReadByte();
            if (hasfield6 == 1)
                field6 = new Struct23(reader);
            field7 = reader.ReadUInt32();
            field8 = reader.ReadBytes(6);
            field9 = reader.ReadUInt64();
            field10 = reader.ReadByte();
            SkillId = reader.ReadUInt32();
            field12 = reader.ReadUInt16();
            ProjectileId = reader.ReadUInt64();
            hasfield14 = reader.ReadByte();
            if (hasfield14 == 1)
                field14 = reader.ReadUInt32();
            SkillEffect = reader.ReadUInt32();
            field16 = reader.ReadUInt32();
            Tripods = reader.ReadBytes(3);
            SkillLevel = reader.ReadByte();
        }
        public Byte field0;
        public UInt16 field1;
        public UInt64 OwnerId;
        public UInt64 field3;
        public UInt64 field4;
        public UInt32 field5;
        public Byte hasfield6;
        public Struct23 field6;
        public UInt32 field7;
        public Byte[] field8;
        public UInt64 field9;
        public Byte field10;
        public UInt32 SkillId;
        public UInt16 field12;
        public UInt64 ProjectileId;
        public Byte hasfield14;
        public UInt32 field14;
        public UInt32 SkillEffect;
        public UInt32 field16;
        public Byte[] Tripods;
        public Byte SkillLevel;
    }
}
