using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public PKTNewNpcSummon(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) SteamDecode(reader);
        }
        public Byte[] field2;
        public Byte[] field0;
        public UInt64 OwnerId;
        public NpcStruct npcStruct;
        public Byte b;
    }
}
