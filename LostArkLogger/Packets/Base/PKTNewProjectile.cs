using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTNewProjectile
    {
        public PKTNewProjectile(BitReader reader)
        {
            if (Properties.Settings.Default.Region == Region.Steam) SteamDecode(reader);
        }
        public ProjectileInfo projectileInfo;
    }
}
