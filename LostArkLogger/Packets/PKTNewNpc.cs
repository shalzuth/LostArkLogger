using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewNpc
    {
        public PKTNewNpc(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public Byte field0;
        public Byte hasfield1;
        public Byte field1;
        public Byte hasfield2;
        public UInt64 field2;
        public NpcStruct npcStruct;
    }
}
