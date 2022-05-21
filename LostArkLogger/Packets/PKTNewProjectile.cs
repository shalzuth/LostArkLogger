using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewProjectile
    {
        public PKTNewProjectile(BitReader reader)
        {
            projectileInfo = reader.Read<ProjectileInfo>();
        }
        public ProjectileInfo projectileInfo;
    }
}
