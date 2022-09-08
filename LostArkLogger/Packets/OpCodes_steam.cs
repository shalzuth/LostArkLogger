using System;
namespace LostArkLogger
{
    public enum OpCodes_Steam : UInt16
    {
        PKTAuthTokenResult = 0x1636,
        PKTCounterAttackNotify = 0x996B,
        PKTDeathNotify = 0x43B5,
        PKTInitEnv = 0xA108,
        PKTInitPC = 0xB3F8,
        PKTNewNpc = 0x4217,
        PKTNewNpcSummon = 0xC844,
        PKTNewPC = 0x2A3,
        PKTNewProjectile = 0x5849,
        PKTPartyStatusEffectAddNotify = 0x5C7E,
        PKTPartyStatusEffectRemoveNotify = 0xD5B,
        PKTRaidBossKillNotify = 0xCA8D,
        PKTRaidResult = 0x3AFA,
        PKTRemoveObject = 0xB4A,
        PKTSkillDamageAbnormalMoveNotify = 0xBC8D,
        PKTSkillDamageNotify = 0xB14C,
        PKTSkillStageNotify = 0x33DB,
        PKTSkillStartNotify = 0x125A,
        PKTStatChangeOriginNotify = 0xD99E,
        PKTStatusEffectAddNotify = 0x683C,
        PKTStatusEffectRemoveNotify = 0x2542,
        PKTTriggerBossBattleStatus = 0x1DEB,
        PKTTriggerStartNotify = 0x1A87,
    }
}
