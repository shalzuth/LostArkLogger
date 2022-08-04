using System;
namespace LostArkLogger
{
    public enum OpCodes_Korea : UInt16
    {
        PKTAuthTokenResult = 0xBE6F,
        PKTCounterAttackNotify = 0x4F00,
        PKTDeathNotify = 0x7410,
        PKTInitEnv = 0x53D,
        PKTInitPC = 0xE072,
        PKTNewNpc = 0x83E5,
        PKTNewNpcSummon = 0x6869,
        PKTNewPC = 0xDFB1,
        PKTNewProjectile = 0x38FD,
        PKTPartyStatusEffectAddNotify = 0x1FF6,
        PKTPartyStatusEffectRemoveNotify = 0xA661,
        PKTRaidBossKillNotify = 0x53AA,
        PKTRaidResult = 0x7AEE,
        PKTRemoveObject = 0x534F,
        PKTSkillDamageAbnormalMoveNotify = 0xA1B9,
        PKTSkillDamageNotify = 0xBD8E,
        PKTSkillStageNotify = 0x9011,
        PKTSkillStartNotify = 0xCB55,
        PKTStatChangeOriginNotify = 0x79CC,
        PKTStatusEffectAddNotify = 0x7DAF,
        PKTStatusEffectRemoveNotify = 0x1BD9,
        PKTTriggerBossBattleStatus = 0x9F6A,
        PKTTriggerStartNotify = 0x1496,
    }
}
