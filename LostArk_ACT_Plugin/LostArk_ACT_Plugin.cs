using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Globalization;

[assembly: AssemblyTitle("Lost Ark Plugin")]
[assembly: AssemblyDescription("Lost Ark DPS plugin")]
[assembly: AssemblyCopyright("shalzuth")]
[assembly: AssemblyVersion("0.0.0.1")]


namespace MLParsing_Plugin
{
    public class LostArk_Plugin : UserControl, IActPluginV1
    {

        #region Designer Created Code (Avoid editing)

        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LostArk_Plugin
            // 
            this.Name = "LostArk_Plugin";
            this.Size = new System.Drawing.Size(75, 68);
            this.ResumeLayout(false);

        }

        #endregion

        #endregion

        public LostArk_Plugin()
        {
            InitializeComponent();
        }
        private DateTime curActionTime = DateTime.MinValue;
        Label lblStatus = null;
        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            ActGlobals.oFormActMain.LogPathHasCharName = false;
            ActGlobals.oFormActMain.LogFileFilter = "LostArk*.log";
            ActGlobals.oFormActMain.LogFileParentFolderName = "LostArkLogs";
            try { ActGlobals.oFormActMain.ResetCheckLogs(); } catch { }
            ActGlobals.oFormActMain.TimeStampLen = 19;
            ActGlobals.oFormActMain.GetDateTimeFromLog = new FormActMain.DateTimeLogParser(ParseDateTime);
            ActGlobals.oFormActMain.BeforeLogLineRead += new LogLineEventDelegate(oFormActMain_BeforeLogLineRead);
            RenameDamageTypes();

            // Set status text to successfully loaded
            lblStatus = pluginStatusText;
            lblStatus.Text = "Lost Ark ACT plugin loaded";
        }
        private void RenameDamageTypes()
        {
            CombatantData.OutgoingDamageTypeDataObjects = new Dictionary<string, CombatantData.DamageTypeDef>
            {
			    {"Outgoing Damage", new CombatantData.DamageTypeDef("Outgoing Damage", 0, Color.Orange)},
                {"Healed (Out)", new CombatantData.DamageTypeDef("Healed (Out)", 1, Color.Blue)},
                {"All Outgoing (Ref)", new CombatantData.DamageTypeDef("All Outgoing (Ref)", 0, Color.Black)}
            };
            CombatantData.IncomingDamageTypeDataObjects = new Dictionary<string, CombatantData.DamageTypeDef>
            {
                {"Incoming Damage", new CombatantData.DamageTypeDef("Incoming Damage", -1, Color.Red)},
                {"Healed (Inc)",new CombatantData.DamageTypeDef("Healed (Inc)", 1, Color.LimeGreen)},
                {"All Incoming (Ref)",new CombatantData.DamageTypeDef("All Incoming (Ref)", 0, Color.Black)}
            };
            CombatantData.SwingTypeToDamageTypeDataLinksOutgoing = new SortedDictionary<int, List<string>>
            {
                {1, new List<string> { "Outgoing Damage" } },
                {2, new List<string> { "Healed (Out)" } },
            };
            CombatantData.SwingTypeToDamageTypeDataLinksIncoming = new SortedDictionary<int, List<string>>
            {
                {1, new List<string> { "Incoming Damage" } },
                {2, new List<string> { "Healed (Inc)" } },
            };

            CombatantData.DamageSwingTypes = new List<int> { 1, 2 };
            CombatantData.HealingSwingTypes = new List<int> { 3 };

            CombatantData.DamageTypeDataNonSkillDamage = "Auto-Attack (Out)";
            CombatantData.DamageTypeDataOutgoingDamage = "Outgoing Damage";
            CombatantData.DamageTypeDataOutgoingHealing = "Healed (Out)";
            CombatantData.DamageTypeDataIncomingDamage = "Incoming Damage";
            CombatantData.DamageTypeDataIncomingHealing = "Healed (Inc)";

            ActGlobals.oFormActMain.ValidateLists();
            ActGlobals.oFormActMain.ValidateTableSetup();
        }
        void oFormActMain_BeforeLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            if (logInfo.detectedTime != curActionTime) curActionTime = logInfo.detectedTime;
            var pl = new ParsedLine(logInfo);
            ProcessAction(pl);
        }
        bool setEncounter = false;
        private void ProcessAction(ParsedLine l)
        {
            l.logInfo.detectedType = Color.Gray.ToArgb();
            // i don't understand encounters in ACT, someone please help.
            /*if (!ActGlobals.oFormActMain.InCombat)
            {
                if (setEncounter == false)
                {
                    setEncounter = true;
                }
                else ActGlobals.oFormActMain.InCombat = true;
            }
            */
            if (ActGlobals.oFormActMain.SetEncounter(l.logInfo.detectedTime, l.attacker, l.victim))
                ActGlobals.oFormActMain.AddCombatAction((int)SwingTypeEnum.Melee, l.critical, "", l.attacker, l.ability, l.damage, l.logInfo.detectedTime, l.ts, l.victim, "");
        }
        private DateTime ParseDateTime(string FullLogLine)
        {
            return DateTime.ParseExact(FullLogLine.Substring(0, 19), "yy':'MM':'dd':'HH':'mm':'ss'.'f", CultureInfo.InvariantCulture);
        }
        public void DeInitPlugin()
        {
            ActGlobals.oFormActMain.BeforeLogLineRead -= oFormActMain_BeforeLogLineRead;
            lblStatus.Text = "Lost Ark ACT plugin unloaded";
        }
    }
    internal class ParsedLine
    {
        public LogLineEventArgs logInfo;
        public int ts;
        public String attacker, victim, ability;
        public Boolean critical, back, front;
        public Int32 damage;

        public ParsedLine(LogLineEventArgs log)
        {
            logInfo = log;
            ts = ++ActGlobals.oFormActMain.GlobalTimeSorter;
            var split = logInfo.logLine.Split(new String[] { "," }, StringSplitOptions.None);
            attacker = split[1];
            victim = split[2];
            ability = split[3];
            damage = Int32.Parse(split[4]);
            critical = split[5] == "1" ? true : false;
            back = split[6] == "1" ? true : false;
            front = split[7] == "1" ? true : false;
        }
    }
}