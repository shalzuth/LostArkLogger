using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class ItemInfo
    {
        public ItemInfo(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public UInt16 Level;
        public UInt64 s64;
        public List<Byte[]> bytearraylist;
        public UInt32 u32;
        public UInt16 u16;
        public Byte b_0;
        public Byte b_1;
    }
}
