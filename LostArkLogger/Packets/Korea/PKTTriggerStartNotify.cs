using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTTriggerStartNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            Signal = reader.ReadUInt32();
            u64list_0 = reader.ReadList<UInt64>();
            TriggerUnitIndex = reader.ReadUInt64();
            ActorId = reader.ReadUInt32();
        }
    }
}
