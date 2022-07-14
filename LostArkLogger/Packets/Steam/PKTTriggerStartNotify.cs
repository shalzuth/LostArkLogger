using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTTriggerStartNotify
    {
        public void SteamDecode(BitReader reader)
        {
            ActorId = reader.ReadUInt32();
            Signal = reader.ReadUInt32();
            TriggerUnitIndex = reader.ReadUInt64();
            u64list = reader.ReadList<UInt64>();
        }
    }
}
