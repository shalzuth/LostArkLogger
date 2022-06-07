using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitPC
    {
        public void SteamDecode(BitReader reader)
        {
            field0 = reader.ReadByte();
            field1 = reader.ReadList<Byte[]>(30);
            field2 = reader.ReadByte();
            Name = reader.ReadString();
            field4 = reader.ReadUInt32();
            field5 = reader.ReadByte();
            field6 = reader.ReadByte();
            field7 = reader.ReadList<UInt16>();
            field8 = reader.ReadUInt16();
            field9 = reader.ReadByte();
            field10 = reader.ReadUInt64();
            pKTNewNpc_1_4_1s = reader.ReadList<PKTNewNpc_1_4_1>();
            field12 = reader.ReadByte();
            ClassId = reader.ReadUInt16();
            field14 = reader.ReadByte();
            hasfield15 = reader.ReadByte();
            if (hasfield15 == 1)
                field15 = reader.ReadUInt32();
            GearLevel = reader.ReadUInt32();
            field17 = reader.ReadUInt64();
            field18 = reader.ReadUInt32();
            field19 = reader.ReadUInt32();
            field20 = reader.ReadUInt32();
            field21 = reader.ReadUInt32();
            field22 = reader.ReadUInt32();
            field23 = reader.ReadByte();
            statusEffectDatas = reader.ReadList<StatusEffectData>();
            field25 = reader.ReadUInt32();
            field26 = reader.ReadUInt16();
            field27 = reader.ReadByte();
            PlayerId = reader.ReadUInt64();
            field29 = reader.ReadUInt32();
            field30 = reader.ReadByte();
            field31 = reader.ReadBytes(35);
            field32 = reader.ReadByte();
            field33 = reader.ReadByte();
            field34 = reader.ReadList<Byte>();
            field35 = reader.ReadUInt64();
            statPair = reader.Read<StatPair>();
            field37 = reader.ReadUInt32();
            field38 = reader.ReadUInt16();
            field39 = reader.ReadByte();
            field40 = reader.ReadUInt32();
            field41 = reader.ReadUInt16();
            field42 = reader.ReadByte();
            field43 = reader.ReadBytes(25);
            field44 = reader.ReadUInt32();
            field45 = reader.ReadByte();
            byteArr0 = reader.ReadBytes(9);
            Level = reader.ReadUInt16();
            byteArr1 = reader.ReadBytes(101);
            field47 = reader.ReadByte();
            field48 = reader.ReadByte();
            field49 = reader.ReadUInt16();
            field50 = reader.ReadByte();
            field51 = reader.ReadByte();
        }
    }
}
