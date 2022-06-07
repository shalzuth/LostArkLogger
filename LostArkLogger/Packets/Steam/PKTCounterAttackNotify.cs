using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTCounterAttackNotify
    {
        public void SteamDecode(BitReader reader)
        {
            field0 = reader.ReadBytes(5);
            TargetId = reader.ReadUInt64();
            field2 = reader.ReadByte();
            SourceId = reader.ReadUInt64();
        }
    }
}
