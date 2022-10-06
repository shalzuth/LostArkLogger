using System;
namespace LostArkLogger
{
    public enum OpCodes_Steam : UInt16
    {
        PKTAuthTokenResult = 0x13CD,
        PKTCounterAttackNotify = 0x4299,
        PKTDeathNotify = 0x5021,
        PKTInitEnv = 0x7D61,
        PKTInitPC = 0x9CDD,
        PKTNewNpc = 0xBCF8,
        PKTNewNpcSummon = 0xE7F5,
        PKTNewPC = 0xB894,
        PKTNewProjectile = 0x9438,
        PKTPartyStatusEffectAddNotify = 0x26D4,
        PKTPartyStatusEffectRemoveNotify = 0x7B,
        PKTRaidBossKillNotify = 0x3242,
        PKTRaidResult = 0xB6CE,
        PKTRemoveObject = 0x2DFE,
        PKTSkillDamageAbnormalMoveNotify = 0x1CC3,
        PKTSkillDamageNotify = 0xE16D,
        PKTSkillStageNotify = 0xDE4B,
        PKTSkillStartNotify = 0x3A2A,
        PKTStatChangeOriginNotify = 0x80E7,
        PKTStatusEffectAddNotify = 0x5B26,
        PKTStatusEffectRemoveNotify = 0xBF,
        PKTTriggerBossBattleStatus = 0x16AB,
        PKTTriggerStartNotify = 0xD6B0,
    }
}
