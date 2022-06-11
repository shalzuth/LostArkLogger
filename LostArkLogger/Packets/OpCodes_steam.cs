using System;
namespace LostArkLogger
{
    public enum OpCodes_Steam : UInt16
    {
        PKTAuthTokenResult = 0x47E4,
        PKTCounterAttackNotify = 0x300A,
        PKTDeathNotify = 0xA716,
        PKTInitEnv = 0xABF1,
        PKTInitPC = 0xB4F5,
        PKTNewNpc = 0x29B0,
        PKTNewNpcSummon = 0x22BE,
        PKTNewPC = 0xCDB7,
        PKTNewProjectile = 0x7684,
        PKTRaidBossKillNotify = 0xB286,
        PKTRaidResult = 0x22A9,
        PKTRemoveObject = 0xB12A,
        PKTSkillDamageAbnormalMoveNotify = 0x7F8D,
        PKTSkillDamageNotify = 0xC17F,
        PKTSkillStageNotify = 0xAC3E,
        PKTSkillStartNotify = 0xE068,
        PKTStatChangeOriginNotify = 0x5949,
        PKTStatusEffectAddNotify = 0xB156,
        PKTTriggerBossBattleStatus = 0x5778,
    }
}
