using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTTriggerStartNotify
    {
        public void SteamDecode(BitReader reader)
        {
            u64list_0 = reader.ReadList<UInt64>();
            Signal = reader.ReadUInt32();
            TriggerUnitIndex = reader.ReadUInt64();
            ActorId = reader.ReadUInt32();
        }
    }
}
