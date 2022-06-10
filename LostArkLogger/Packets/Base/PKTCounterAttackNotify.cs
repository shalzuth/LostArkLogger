using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTCounterAttackNotify
    {
        public PKTCounterAttackNotify(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
            if (Properties.Settings.Default.Region == Region.Korea) KoreaDecode(reader);
        }
        public UInt64 SourceId;
        public UInt64 TargetId;
        public Byte[] bytearray_0;
        public Byte[] bytearray_1;
        public Byte[] bytearray_2;
    }
}
