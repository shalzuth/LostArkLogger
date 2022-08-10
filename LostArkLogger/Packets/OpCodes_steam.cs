using System;
namespace LostArkLogger
{
    public enum OpCodes_Steam : UInt16
    {
        PKTAuthTokenResult = 0x7500,
        PKTCounterAttackNotify = 0x5436,
        PKTDeathNotify = 0x482,
        PKTInitEnv = 0xAB18,
        PKTInitPC = 0x480F,
        PKTNewNpc = 0xEA6,
        PKTNewNpcSummon = 0xBAAE,
        PKTNewPC = 0x716A,
        PKTNewProjectile = 0x349,
        PKTPartyStatusEffectAddNotify = 0x6FD8,
        PKTPartyStatusEffectRemoveNotify = 0x5765,
        PKTRaidBossKillNotify = 0x499E,
        PKTRaidResult = 0x70E9,
        PKTRemoveObject = 0x8A8,
        PKTSkillDamageAbnormalMoveNotify = 0x2B51,
        PKTSkillDamageNotify = 0x5DBA,
        PKTSkillStageNotify = 0x946F,
        PKTSkillStartNotify = 0x3829,
        PKTStatChangeOriginNotify = 0x5004,
        PKTStatusEffectAddNotify = 0x496E,
        PKTStatusEffectRemoveNotify = 0xA483,
        PKTTriggerBossBattleStatus = 0x1C34,
        PKTTriggerStartNotify = 0x2706,
    }
}
