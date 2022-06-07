using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTSkillStartNotify
    {
        public void SteamDecode(BitReader reader)
        {
            field0 = reader.ReadUInt64();
            hasfield1 = reader.ReadByte();
            if (hasfield1 == 1)
                field1 = reader.ReadUInt32();
            field2 = reader.ReadUInt16();
            field3 = reader.ReadByte();
            field4 = reader.ReadUInt16();
            hasfield5 = reader.ReadByte();
            if (hasfield5 == 1)
                field5 = reader.ReadUInt16();
            field6 = reader.ReadUInt64();
            field7 = reader.ReadPackedValues(1, 1, 4, 4, 4, 3, 6);
            SourceId = reader.ReadUInt64();
            hasfield9 = reader.ReadByte();
            if (hasfield9 == 1)
                field9 = reader.ReadUInt32();
            field10 = reader.ReadUInt64();
            SkillId = reader.ReadUInt32();
        }
    }
}
