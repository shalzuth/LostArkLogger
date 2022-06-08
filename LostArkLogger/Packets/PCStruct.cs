using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PCStruct
    {
        public PCStruct(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) SteamDecode(reader);
        }
        public PKTNewNpc_1_2_2 pKTNewNpc_1_2_2;
        public Byte hasfield1;
        public Byte[] field1;
        public Byte field2;
        public Byte field3;
        public Byte field4;
        public UInt32 field5;
        public Byte field6;
        public UInt32 field7;
        public Byte field8;
        public List<ItemInfo> itemInfos;
        public UInt16 ClassId;
        public SkillRunes skillRunes;
        public UInt32 GearLevel;
        public UInt64 field13;
        public UInt64 field14;
        public UInt32 field15;
        public List<UInt32> field16;
        public String Name;
        public UInt32 field18;
        public UInt16 field19;
        public UInt32 field20;
        public Byte field21;
        public List<ItemInfo> EquippedItems;
        public Byte[] field23;
        public UInt32 field24;
        public Byte field25;
        public UInt32 field26;
        public List<StatusEffectData> statusEffectDatas;
        public UInt16 field28;
        public Byte field29;
        public String Guild;
        public Byte field31;
        public Byte field32;
        public Byte[] field33;
        public UInt16 field34;
        public UInt64 PlayerId;
        public Byte field36;
        public UInt16 Level;
        public UInt16 field38;
        public UInt32 field39;
        public StatPair statPair;
        public Byte field41;
        public UInt32 field42;
        public List<PKTNewNpc_1_4_1> pKTNewNpc_1_4_1s;
    }
}
