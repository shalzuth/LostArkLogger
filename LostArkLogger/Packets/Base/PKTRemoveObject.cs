using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTRemoveObject
    {
        public PKTRemoveObject(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
        }
        public List<Byte> blist;
    }
}
