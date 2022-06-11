using System;
namespace LostArkLogger
{
    public enum OpCodes_Korea : UInt16
    {
        PKTAuthTokenResult = 0x6057,
        PKTCounterAttackNotify = 0x75D,
        PKTDeathNotify = 0x83E0,
        PKTInitEnv = 0xD3C,
        PKTInitPC = 0xCCF4,
        PKTNewNpc = 0x8508,
        PKTNewNpcSummon = 0x2040,
        PKTNewPC = 0x7994,
        PKTNewProjectile = 0x218F,
        PKTRaidBossKillNotify = 0xB850,
        PKTRaidResult = 0xDB30,
        PKTRemoveObject = 0x30AE,
        PKTSkillDamageAbnormalMoveNotify = 0x9305,
        PKTSkillDamageNotify = 0x457E,
        PKTSkillStageNotify = 0x2B4,
        PKTSkillStartNotify = 0x740A,
        PKTStatChangeOriginNotify = 0x32C6,
        PKTStatusEffectAddNotify = 0xC781,
        PKTTriggerBossBattleStatus = 0xC8F5,
    }
}
