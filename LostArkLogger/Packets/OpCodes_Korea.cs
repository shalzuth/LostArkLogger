using System;
namespace LostArkLogger
{
    public enum OpCodes_Korea : UInt16
    {
        PKTAuthTokenResult = 0x7727,
        PKTCounterAttackNotify = 0x31A9,
        PKTDeathNotify = 0xC55B,
        PKTInitEnv = 0x17C0,
        PKTInitPC = 0x7F2A,
        PKTNewNpc = 0xDE6D,
        PKTNewNpcSummon = 0xC068,
        PKTNewPC = 0x448F,
        PKTNewProjectile = 0x8885,
        PKTPartyStatusEffectAddNotify = 0xCB2C,
        PKTPartyStatusEffectRemoveNotify = 0xC1CD,
        PKTRaidBossKillNotify = 0x2672,
        PKTRaidResult = 0x3A9E,
        PKTRemoveObject = 0x66A3,
        PKTSkillDamageAbnormalMoveNotify = 0xA3D1,
        PKTSkillDamageNotify = 0xBF37,
        PKTSkillStageNotify = 0xBFBE,
        PKTSkillStartNotify = 0x5730,
        PKTStatChangeOriginNotify = 0x63F2,
        PKTStatusEffectAddNotify = 0x443E,
        PKTStatusEffectRemoveNotify = 0xCD67,
        PKTTriggerBossBattleStatus = 0x61A6,
        PKTTriggerStartNotify = 0x9528,
    }
}
