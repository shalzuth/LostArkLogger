using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public PKTNewNpcSummon(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public UInt64 OwnerId;
        public NpcStruct npcStruct;
        public Byte[] bytearray_0;
        public Byte[] bytearray_1;
        public Byte b_0;
    }
}
