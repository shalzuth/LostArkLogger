using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatusEffectRemoveNotify
    {
        public void SteamDecode(BitReader reader)
        {
            InstanceIds = reader.ReadList<UInt32>();
            Reason = reader.ReadByte();
            ObjectId = reader.ReadUInt64();
        }
    }
}
