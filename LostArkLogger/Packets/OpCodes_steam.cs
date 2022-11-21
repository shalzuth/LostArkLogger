using System;
namespace LostArkLogger
{
    public enum OpCodes_Steam : UInt16
    {
        PKTAuthTokenResult = 0xBA70,
        PKTCounterAttackNotify = 0x5727,
        PKTDeathNotify = 0xE82E,
        PKTInitEnv = 0x957C,
        PKTInitPC = 0x6E6B,
        PKTNewNpc = 0x6BB4,
        PKTNewNpcSummon = 0x70EE,
        PKTNewPC = 0x6694,
        PKTNewProjectile = 0x3ED7,
        PKTPartyStatusEffectAddNotify = 0xE190,
        PKTPartyStatusEffectRemoveNotify = 0xC90F,
        PKTRaidBossKillNotify = 0x4590,
        PKTRaidResult = 0x927C,
        PKTRemoveObject = 0x8216,
        PKTSkillDamageAbnormalMoveNotify = 0x92DD,
        PKTSkillDamageNotify = 0xE1A6,
        PKTSkillStageNotify = 0x835,
        PKTSkillStartNotify = 0xE9FF,
        PKTStatChangeOriginNotify = 0x1F13,
        PKTStatusEffectAddNotify = 0xA209,
        PKTStatusEffectRemoveNotify = 0xA8B3,
        PKTTriggerBossBattleStatus = 0xE5F7,
        PKTTriggerStartNotify = 0x7807,
    }
}
