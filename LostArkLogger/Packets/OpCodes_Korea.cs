using System;
namespace LostArkLogger
{
    public enum OpCodes_Korea : UInt16
    {
        PKTAuthTokenResult = 0xB126,
        PKTCounterAttackNotify = 0x698A,
        PKTDeathNotify = 0xA66B,
        PKTInitEnv = 0x177C,
        PKTInitPC = 0xA904,
        PKTNewNpc = 0x2730,
        PKTNewNpcSummon = 0x4BF5,
        PKTNewPC = 0x53CD,
        PKTNewProjectile = 0x17D4,
        PKTPartyStatusEffectAddNotify = 0xDC40,
        PKTPartyStatusEffectRemoveNotify = 0x333E,
        PKTRaidBossKillNotify = 0x58E7,
        PKTRaidResult = 0x2B,
        PKTRemoveObject = 0x7317,
        PKTSkillDamageAbnormalMoveNotify = 0x87D8,
        PKTSkillDamageNotify = 0x5F70,
        PKTSkillStageNotify = 0xDD58,
        PKTSkillStartNotify = 0x354,
        PKTStatChangeOriginNotify = 0x4692,
        PKTStatusEffectAddNotify = 0xC4FA,
        PKTStatusEffectRemoveNotify = 0x583D,
        PKTTriggerBossBattleStatus = 0x3079,
        PKTTriggerStartNotify = 0xD25E,
    }
}
