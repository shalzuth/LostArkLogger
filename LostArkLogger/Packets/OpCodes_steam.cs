using System;
namespace LostArkLogger
{
    public enum OpCodes_Steam : UInt16
    {
        PKTAuthTokenResult = 0x401C,
        PKTCounterAttackNotify = 0xC679,
        PKTDeathNotify = 0x950A,
        PKTInitEnv = 0xEA55,
        PKTInitPC = 0x8F3A,
        PKTNewNpc = 0x368E,
        PKTNewNpcSummon = 0x3DC,
        PKTNewPC = 0x8159,
        PKTNewProjectile = 0x2213,
        PKTRaidBossKillNotify = 0x7233,
        PKTRaidResult = 0x3A8,
        PKTRemoveObject = 0x174D,
        PKTSkillDamageAbnormalMoveNotify = 0x5395,
        PKTSkillDamageNotify = 0xA17A,
        PKTSkillStageNotify = 0xCF8D,
        PKTSkillStartNotify = 0xC373,
        PKTStatChangeOriginNotify = 0x32DA,
        PKTStatusEffectAddNotify = 0x42A5,
        PKTTriggerBossBattleStatus = 0x76E0,
    }
}
