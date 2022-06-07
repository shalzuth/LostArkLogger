using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTRemoveObject
    {
        public void SteamDecode(BitReader reader)
        {
            field0 = reader.ReadUInt64();
            field1 = reader.ReadString();
        }
    }
}
