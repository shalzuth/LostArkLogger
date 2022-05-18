using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public class PKTNewProjectile
    {
        public PKTNewProjectile(BitReader reader)
        {
            Info = new ProjectileInfo(reader);
        }
        public ProjectileInfo Info; //0
    }
}
