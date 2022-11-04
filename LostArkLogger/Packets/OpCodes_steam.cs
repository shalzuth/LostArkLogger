using System;
namespace LostArkLogger
{
    public enum OpCodes_Steam : UInt16
    {
        PKTAuthTokenResult = 0x8936,
        PKTCounterAttackNotify = 0xB931,
        PKTDeathNotify = 0x1CCE,
        PKTInitEnv = 0xE05,
        PKTInitPC = 0x7BC2,
        PKTNewNpc = 0x20C5,
        PKTNewNpcSummon = 0x5FF4,
        PKTNewPC = 0x890F,
        PKTNewProjectile = 0xCA0,
        PKTPartyStatusEffectAddNotify = 0x0,
        PKTPartyStatusEffectRemoveNotify = 0x0,
        PKTRaidBossKillNotify = 0x3D74,
        PKTRaidResult = 0xCF87,
        PKTRemoveObject = 0xDB39,
        PKTSkillDamageAbnormalMoveNotify = 0x6D28,
        PKTSkillDamageNotify = 0x3A44,
        PKTSkillStageNotify = 0x99B5,
        PKTSkillStartNotify = 0x41AD,
        PKTStatChangeOriginNotify = 0xBE5E,
        PKTStatusEffectAddNotify = 0x29C5,
        PKTStatusEffectRemoveNotify = 0xA98E,
        PKTTriggerBossBattleStatus = 0x8A2,
        PKTTriggerStartNotify = 0x61C3,
    }
}
