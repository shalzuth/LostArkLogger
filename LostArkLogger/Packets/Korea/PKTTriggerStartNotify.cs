using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTTriggerStartNotify
    {
        public void KoreaDecode(BitReader reader)
        {
            u64list_0 = reader.ReadList<UInt64>();
            TriggerUnitIndex = reader.ReadUInt64();
            ActorId = reader.ReadUInt32();
            Signal = reader.ReadUInt32();
        }
    }
}
