using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpcSummon
    {
        public PKTNewNpcSummon(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public Byte field0;
        public Byte[] subfield0;
        public UInt64 OwnerId;
        public Byte[] subfield1;
        public NpcStruct npcStruct;
    }
}
