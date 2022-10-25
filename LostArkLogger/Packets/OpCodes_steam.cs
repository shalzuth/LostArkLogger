using System;
namespace LostArkLogger
{
    public enum OpCodes_Steam : UInt16
    {
        PKTAuthTokenResult = 0x3299,
        PKTCounterAttackNotify = 0x9CFE,
        PKTDeathNotify = 0xD545,
        PKTInitEnv = 0x26C4,
        PKTInitPC = 0xD374,
        PKTNewNpc = 0x13A9,
        PKTNewNpcSummon = 0x9ABF,
        PKTNewPC = 0x219B,
        PKTNewProjectile = 0x3E70,
        PKTPartyStatusEffectAddNotify = 0xD466,
        PKTPartyStatusEffectRemoveNotify = 0x3E66,
        PKTRaidBossKillNotify = 0x7E9,
        PKTRaidResult = 0x93AE,
        PKTRemoveObject = 0x29DC,
        PKTSkillDamageAbnormalMoveNotify = 0x55E1,
        PKTSkillDamageNotify = 0xC32A,
        PKTSkillStageNotify = 0xC925,
        PKTSkillStartNotify = 0xA868,
        PKTStatChangeOriginNotify = 0xE100,
        PKTStatusEffectAddNotify = 0xA6E0,
        PKTStatusEffectRemoveNotify = 0x53B7,
        PKTTriggerBossBattleStatus = 0x4FB3,
        PKTTriggerStartNotify = 0xAC98,
    }
}
