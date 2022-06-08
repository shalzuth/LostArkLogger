using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class NpcStruct
    {
        public NpcStruct(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) SteamDecode(reader);
        }
        public UInt16 field0;
        public Byte field1;
        public Byte hasfield2;
        public Byte field2;
        public Byte hasfield3;
        public UInt32 field3;
        public StatPair statPair;
        public Byte hasfield5;
        public Byte field5;
        public Byte hasfield6;
        public Byte field6;
        public Byte hasfield7;
        public Byte field7;
        public Byte hasfield8;
        public UInt32 field8;
        public Byte field9;
        public Byte field10;
        public Byte hasfield11;
        public PKTNewNpc_1_2 pKTNewNpc_1_2;
        public Byte hasfield12;
        public Byte field12;
        public Byte field13;
        public Byte hasfield14;
        public UInt64 field14;
        public UInt32 NpcType;
        public Byte hasfield16;
        public Byte field16;
        public Byte hasfield17;
        public UInt32 field17;
        public Byte hasfield18;
        public UInt16 field18;
        public Byte hasfield19;
        public UInt32 field19;
        public Byte hasfield20;
        public List<UInt64> field20;
        public Byte field21;
        public UInt16 field22;
        public List<PKTNewNpc_1_4_1> pKTNewNpc_1_4_1s;
        public Byte hasfield24;
        public UInt16 field24;
        public UInt32 field25;
        public UInt64 NpcId;
        public Byte hasfield27;
        public UInt32 field27;
        public Byte field28;
        public Byte hasfield29;
        public Byte field29;
        public Byte hasfield30;
        public List<Byte[]> field30;
        public UInt64 field31;
        public List<StatusEffectData> statusEffectDatas;
    }
}
