using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTInitPC
    {
        public PKTInitPC(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) SteamDecode(reader);
        }
        public Byte field0;
        public List<Byte[]> field1;
        public Byte field2;
        public String Name;
        public UInt32 field4;
        public Byte field5;
        public Byte field6;
        public List<UInt16> field7;
        public UInt16 field8;
        public Byte field9;
        public UInt64 field10;
        public List<PKTNewNpc_1_4_1> pKTNewNpc_1_4_1s;
        public Byte field12;
        public UInt16 ClassId;
        public Byte field14;
        public Byte hasfield15;
        public UInt32 field15;
        public UInt32 GearLevel;
        public UInt64 field17;
        public UInt32 field18;
        public UInt32 field19;
        public UInt32 field20;
        public UInt32 field21;
        public UInt32 field22;
        public Byte field23;
        public List<StatusEffectData> statusEffectDatas;
        public UInt32 field25;
        public UInt16 field26;
        public Byte field27;
        public UInt64 PlayerId;
        public UInt32 field29;
        public Byte field30;
        public Byte[] field31;
        public Byte field32;
        public Byte field33;
        public List<Byte> field34;
        public UInt64 field35;
        public StatPair statPair;
        public UInt32 field37;
        public UInt16 field38;
        public Byte field39;
        public UInt32 field40;
        public UInt16 field41;
        public Byte field42;
        public Byte[] field43;
        public UInt32 field44;
        public Byte field45;
        public Byte[] byteArr0;
        public UInt16 Level;
        public Byte[] byteArr1;
        public Byte field47;
        public Byte field48;
        public UInt16 field49;
        public Byte field50;
        public Byte field51;
    }
}
