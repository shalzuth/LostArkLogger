using System;
namespace LostArkLogger
{
    public enum OpCodes_steam : UInt16
    {
        PKTAuthTokenResult = 18404,
        PKTCounterAttackNotify = 12298,
        PKTDeathNotify = 42774,
        PKTInitEnv = 44017,
        PKTInitPC = 46325,
        PKTNewNpc = 10672,
        PKTNewNpcSummon = 8894,
        PKTNewPC = 52663,
        PKTNewProjectile = 30340,
        PKTRaidBossKillNotify = 45702,
        PKTRaidResult = 39662,
        PKTRemoveObject = 49332,
        PKTSkillDamageAbnormalMoveNotify = 32653,
        PKTSkillDamageNotify = 49535,
        PKTSkillStageNotify = 44094,
        PKTSkillStartNotify = 57448,
        PKTStatChangeOriginNotify = 22857,
        PKTStatusEffectAddNotify = 40631,
        PKTTriggerBossBattleStatus = 22392,
    }
}
