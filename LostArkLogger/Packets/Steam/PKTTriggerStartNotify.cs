using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTTriggerStartNotify
    {
        public void SteamDecode(BitReader reader)
        {
            u64list_0 = reader.ReadList<UInt64>();
            TriggerUnitIndex = reader.ReadUInt64();
            Signal = reader.ReadUInt32();
            ActorId = reader.ReadUInt32();
        }
    }
}
