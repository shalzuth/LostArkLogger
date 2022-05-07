using System;
namespace LostArkLogger
{
    public class LogInfo
    {
        public DateTime Time { get; set; }
        public Entity SourceEntity { get; set; }
        public Entity DestinationEntity { get; set; }
        public String SkillName { get; set; }
        public UInt64 Damage { get; set; }
        public Boolean Crit { get; set; }
        public Boolean BackAttack { get; set; }
        public Boolean FrontAttack { get; set; }
        public Boolean Counter { get; set; }
        public override string ToString()
        {
            return Time.ToString("yy:MM:dd:HH:mm:ss.f") + "," +
                   SourceEntity.VisibleName + "," +
                   DestinationEntity.VisibleName + "," +
                   SkillName + "," +
                   Damage + "," +
                   (Crit ? "1" : "0") + "," +
                   (BackAttack ? "1" : "0") + "," +
                   (FrontAttack ? "1" : "0") + "," +
                   (Counter ? "1" : "0");
        }
    }
}
