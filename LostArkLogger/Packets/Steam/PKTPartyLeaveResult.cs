using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public partial class PKTPartyLeaveResult
    {
        public void SteamDecode(BitReader reader)
        {
            b_0 = reader.ReadByte();
            PartyInstanceId = reader.ReadUInt32();
            Name = reader.ReadString();
        }
    }
}
