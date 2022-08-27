using System;
namespace LostArkLogger
{
    public enum OpCodes_Steam : UInt16
    {
        PKTAuthTokenResult = 0x67F6,
        PKTCounterAttackNotify = 0x5149,
        PKTDeathNotify = 0xB4BF,
        PKTInitEnv = 0x7F6A,
        PKTInitPC = 0xDC91,
        PKTNewNpc = 0x6155,
        PKTNewNpcSummon = 0xB3BA,
        PKTNewPC = 0xB1FA,
        PKTNewProjectile = 0xBF3F,
        PKTPartyStatusEffectAddNotify = 0xD7A0,
        PKTPartyStatusEffectRemoveNotify = 0x9E74,
        PKTRaidBossKillNotify = 0xC24A,
        PKTRaidResult = 0x6741,
        PKTRemoveObject = 0x57E4,
        PKTSkillDamageAbnormalMoveNotify = 0x7BD1,
        PKTSkillDamageNotify = 0xC45,
        PKTSkillStageNotify = 0x58F5,
        PKTSkillStartNotify = 0x9C88,
        PKTStatChangeOriginNotify = 0x5B82,
        PKTStatusEffectAddNotify = 0x6154,
        PKTStatusEffectRemoveNotify = 0xB6A9,
        PKTTriggerBossBattleStatus = 0x1395,
        PKTTriggerStartNotify = 0x5601,
    }
}
