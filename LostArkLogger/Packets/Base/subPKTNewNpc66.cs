using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class subPKTNewNpc66
    {
        public subPKTNewNpc66(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public String str;
        public List<ItemInfo> itemInfos;
        public subPKTNewNpc5 subPKTNewNpc5;
        public UInt64 u64;
        public UInt16 u16;
        public Byte b_0;
        public Byte b_1;
        public Byte b_2;
    }
}
