using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTRemoveObject
    {
        public void SteamDecode(BitReader reader)
        {
            blist = reader.ReadList<Byte>();
        }
    }
}
