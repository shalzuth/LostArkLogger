using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public partial class PKTPartyLeaveResult
    {
        public PKTPartyLeaveResult(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
        }
        public byte b_0;
        public UInt32 PartyInstanceId;
        public string Name;

    }
}
