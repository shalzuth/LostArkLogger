using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTTriggerStartNotify
    {
        public void SteamDecode(BitReader reader)
        {
            TriggerUnitIndex = reader.ReadUInt64();
            Signal = reader.ReadUInt32();
            u64list = reader.ReadList<UInt64>();
            ActorId = reader.ReadUInt32();
        }
    }
}
