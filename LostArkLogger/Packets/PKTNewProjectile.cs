using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewProjectile
    {
        public PKTNewProjectile(BitReader reader)
        {
            if (Parser.region == Parser.Region.Steam) SteamDecode(reader);
            if (Parser.region == Parser.Region.Korea) SteamDecode(reader);
        }
        public ProjectileInfo projectileInfo;
    }
}
