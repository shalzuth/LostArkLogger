using System;
namespace LostArkLogger
{
    public enum OpCodes_Korea : UInt16
    {
        PKTAuthTokenResult = 0x103C,
        PKTCounterAttackNotify = 0x2743,
        PKTDeathNotify = 0x655B,
        PKTInitEnv = 0xE42E,
        PKTInitPC = 0x6514,
        PKTNewNpc = 0x2FB3,
        PKTNewNpcSummon = 0x8103,
        PKTNewPC = 0xA64C,
        PKTNewProjectile = 0x672F,
        PKTPartyStatusEffectAddNotify = 0xE87C,
        PKTPartyStatusEffectRemoveNotify = 0x42FD,
        PKTRaidBossKillNotify = 0x5D3C,
        PKTRaidResult = 0x1833,
        PKTRemoveObject = 0x79DA,
        PKTSkillDamageAbnormalMoveNotify = 0xD1DB,
        PKTSkillDamageNotify = 0x3724,
        PKTSkillStageNotify = 0xAD44,
        PKTSkillStartNotify = 0x14A2,
        PKTStatChangeOriginNotify = 0x4D15,
        PKTStatusEffectAddNotify = 0xDCE2,
        PKTStatusEffectRemoveNotify = 0x1B2F,
        PKTTriggerBossBattleStatus = 0x91B0,
        PKTTriggerStartNotify = 0x17B0,
    }
}
