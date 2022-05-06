using System;
using System.Collections.Generic;

namespace LostArkLogger
{
    public class Entity
    {
        public UInt64 EntityId;
        public UInt64 OwnerId;
        public String Name;
        public String ClassName = "";
        public EntityType Type;

        public override int GetHashCode()
        {
            return (int)EntityId;
        }

        public enum EntityType
        {
            Player = 0,
            Npc = 1,
            Projectile = 2,
            Minion = 3,
        }
    }
}
