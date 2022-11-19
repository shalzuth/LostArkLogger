using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTStatusEffectRemoveNotify
    {
        public void SteamDecode(BitReader reader)
        {
            ObjectId = reader.ReadUInt64();
            Reason = reader.ReadByte();
            InstanceIds = reader.ReadList<UInt32>();
        }
    }
}
