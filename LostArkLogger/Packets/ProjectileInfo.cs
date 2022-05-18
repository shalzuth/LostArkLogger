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
        public Byte field0; //0
        public UInt16 field1; //2
        public UInt64 OwnerId; //8
        public UInt64 field3; //16
        public UInt64 field4; //24
        public UInt32 field5; //32
        public Byte hasfield6; //126
        public Struct23 field6; //36
        public UInt32 field7; //128
        public Byte[] field8; //132
        public UInt64 field9; //144
        public Byte field10; //152
        public UInt32 SkillId; //156
        public UInt16 field12; //160
        public UInt64 ProjectileId; //168
        public Byte hasfield14; //180
        public UInt32 field14; //176
        public UInt32 SkillEffect; //184
        public UInt32 field16; //188
        public Byte[] Tripods; //192
        public Byte SkillLevel; //195
    }
}
