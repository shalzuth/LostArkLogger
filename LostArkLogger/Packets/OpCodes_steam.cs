using System;
namespace LostArkLogger
{
    public enum OpCodes_Steam : UInt16
    {
        PKTAuthTokenResult = 0x944D,
        PKTCounterAttackNotify = 0xA431,
        PKTDeathNotify = 0x45F4,
        PKTInitEnv = 0x8E87,
        PKTInitPC = 0x7B79,
        PKTNewNpc = 0xA8C2,
        PKTNewNpcSummon = 0x9209,
        PKTNewPC = 0xA5E3,
        PKTNewProjectile = 0xC922,
        PKTPartyStatusEffectAddNotify = 0x2458,
        PKTPartyStatusEffectRemoveNotify = 0x528C,
        PKTRaidBossKillNotify = 0xC,
        PKTRaidResult = 0x4AA3,
        PKTRemoveObject = 0x3203,
        PKTSkillDamageAbnormalMoveNotify = 0xCE05,
        PKTSkillDamageNotify = 0x5D14,
        PKTSkillStageNotify = 0x2C23,
        PKTSkillStartNotify = 0x5EAE,
        PKTStatChangeOriginNotify = 0xE186,
        PKTStatusEffectAddNotify = 0xC7DB,
        PKTStatusEffectRemoveNotify = 0xE873,
        PKTTriggerBossBattleStatus = 0xC3C2,
        PKTTriggerStartNotify = 0x8655,
    }
}
