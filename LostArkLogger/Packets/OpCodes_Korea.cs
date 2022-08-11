using System;
namespace LostArkLogger
{
    public enum OpCodes_Korea : UInt16
    {
        PKTAuthTokenResult = 0x79C4,
        PKTCounterAttackNotify = 0x8C9A,
        PKTDeathNotify = 0xBCAE,
        PKTInitEnv = 0xA0A2,
        PKTInitPC = 0x2D55,
        PKTNewNpc = 0x3189,
        PKTNewNpcSummon = 0x73DC,
        PKTNewPC = 0x231,
        PKTNewProjectile = 0xBE19,
        PKTPartyStatusEffectAddNotify = 0x352A,
        PKTPartyStatusEffectRemoveNotify = 0x6FB0,
        PKTRaidBossKillNotify = 0x98E9,
        PKTRaidResult = 0xB3FE,
        PKTRemoveObject = 0x12B9,
        PKTSkillDamageAbnormalMoveNotify = 0xAF0D,
        PKTSkillDamageNotify = 0x58E1,
        PKTSkillStageNotify = 0x83F4,
        PKTSkillStartNotify = 0x680A,
        PKTStatChangeOriginNotify = 0x652A,
        PKTStatusEffectAddNotify = 0xA005,
        PKTStatusEffectRemoveNotify = 0xDF4F,
        PKTTriggerBossBattleStatus = 0x8F97,
        PKTTriggerStartNotify = 0xE411,
    }
}
