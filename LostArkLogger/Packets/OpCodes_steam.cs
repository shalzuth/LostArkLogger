using System;
namespace LostArkLogger
{
    public enum OpCodes_Steam : UInt16
    {
        PKTAuthTokenResult = 0x2D5F,
        PKTCounterAttackNotify = 0xADD6,
        PKTDeathNotify = 0x84C3,
        PKTInitEnv = 0xD5FB,
        PKTInitPC = 0x3631,
        PKTNewNpc = 0xDC24,
        PKTNewNpcSummon = 0x26C7,
        PKTNewPC = 0x348E,
        PKTNewProjectile = 0xC089,
        PKTPartyStatusEffectAddNotify = 0x9B50,
        PKTPartyStatusEffectRemoveNotify = 0x5FAD,
        PKTRaidBossKillNotify = 0xDC79,
        PKTRaidResult = 0x2A4,
        PKTRemoveObject = 0x5439,
        PKTSkillDamageAbnormalMoveNotify = 0xFC8,
        PKTSkillDamageNotify = 0x5391,
        PKTSkillStageNotify = 0x12A7,
        PKTSkillStartNotify = 0xCF9,
        PKTStatChangeOriginNotify = 0x2DBA,
        PKTStatusEffectAddNotify = 0x1E87,
        PKTStatusEffectRemoveNotify = 0xE5C5,
        PKTTriggerBossBattleStatus = 0x5647,
        PKTTriggerStartNotify = 0x8311,
    }
}
