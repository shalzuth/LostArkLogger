using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public partial class PKTPartyUnknown
    {
        public void SteamDecode(BitReader reader)
        {
            CharacterId = reader.ReadUInt64();
            ba_0 = reader.ReadBytes(8);
            PartyInstanceId = reader.ReadUInt32();
            u32_0 = reader.ReadUInt32();
            RaidInstanceId = reader.ReadUInt32();
            b_0 = reader.ReadByte();
            u16_0 = reader.ReadUInt16();
            b_1 = reader.ReadByte();
            u64_0 = reader.ReadUInt64();
            ba_1 = reader.ReadBytes(3);
        }
    }
}
