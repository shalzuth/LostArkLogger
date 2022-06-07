using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class ProjectileInfo
    {
        public void SteamDecode(BitReader reader)
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
    }
}
