using System;
namespace LostArkLogger
{
    public class LogInfo
    {
        public DateTime Time { get; set; }
        public String Source { get; set; }
        public Boolean PC { get; set; }
        public String Destination { get; set; }
        public String SkillName { get; set; }
        public UInt64 Damage { get; set; }
        public Boolean Crit { get; set; }
        public Boolean BackAttack { get; set; }
        public Boolean FrontAttack { get; set; }
        public override string ToString()
        {
            return Time.ToString("yy:MM:dd:HH:mm:ss.f") + "," +
                   Source + "," +
                   Destination + "," +
                   SkillName + "," +
                   Damage + "," +
                   (Crit ? "1" : "0") + "," +
                   (BackAttack ? "1" : "0") + "," +
                   (FrontAttack ? "1" : "0");
            return Time.ToString("yy:MM:dd:HH:mm:ss.f") + "," +
                   Source + "," +
                   PC + "," +
                   Destination + "," +
                   SkillName + "," +
                   Damage + "," +
                   (Crit ? "1" : "0") + "," +
                   (BackAttack ? "1" : "0") + "," +
                   (FrontAttack ? "1" : "0");
        }
    }
}
