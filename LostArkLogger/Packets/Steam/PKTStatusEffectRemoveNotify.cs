using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatusEffectRemoveNotify
    {
        public void SteamDecode(BitReader reader)
        {
            Reason = reader.ReadByte();
            ObjectId = reader.ReadUInt64();
            InstanceIds = reader.ReadList<UInt32>();
        }
    }
}
