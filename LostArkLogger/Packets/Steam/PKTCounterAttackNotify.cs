using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTCounterAttackNotify
    {
        public void SteamDecode(BitReader reader)
        {
            field0 = reader.ReadBytes(5);
            SourceId = reader.ReadUInt64();
            field2 = reader.ReadBytes(1);
            TargetId = reader.ReadUInt64();
            field4 = reader.ReadBytes(0);
        }
    }
}
