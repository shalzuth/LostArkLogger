using System;
namespace LostArkLogger
{
    public enum OpCodes_Steam : UInt16
    {
        PKTAuthTokenResult = 0x6E5A,
        PKTCounterAttackNotify = 0x2904,
        PKTDeathNotify = 0xD1E1,
        PKTInitEnv = 0x7761,
        PKTInitPC = 0x9657,
        PKTNewNpc = 0xE461,
        PKTNewNpcSummon = 0x9E4B,
        PKTNewPC = 0x5C50,
        PKTNewProjectile = 0xAB18,
        PKTPartyStatusEffectAddNotify = 0x8220,
        PKTPartyStatusEffectRemoveNotify = 0x376F,
        PKTRaidBossKillNotify = 0x9AD7,
        PKTRaidResult = 0x963B,
        PKTRemoveObject = 0x7007,
        PKTSkillDamageAbnormalMoveNotify = 0x5D3F,
        PKTSkillDamageNotify = 0x39FE,
        PKTSkillStageNotify = 0x7558,
        PKTSkillStartNotify = 0x3383,
        PKTStatChangeOriginNotify = 0x1026,
        PKTStatusEffectAddNotify = 0x87D8,
        PKTStatusEffectRemoveNotify = 0x6890,
        PKTTriggerBossBattleStatus = 0x40D3,
        PKTTriggerStartNotify = 0x54F9,
    }
}
