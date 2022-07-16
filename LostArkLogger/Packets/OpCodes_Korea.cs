using System;
namespace LostArkLogger
{
    public enum OpCodes_Korea : UInt16
    {
        PKTAuthTokenResult = 0x7736,
        PKTCounterAttackNotify = 0xE5A6,
        PKTDeathNotify = 0x4B4B,
        PKTInitEnv = 0x4D93,
        PKTInitPC = 0x69D3,
        PKTNewNpc = 0x32F1,
        PKTNewNpcSummon = 0x1F6E,
        PKTNewPC = 0xA382,
        PKTNewProjectile = 0x35C,
        PKTPartyStatusEffectAddNotify = 0xCCB1,
        PKTPartyStatusEffectRemoveNotify = 0xAFE,
        PKTRaidBossKillNotify = 0xB2CB,
        PKTRaidResult = 0x9380,
        PKTRemoveObject = 0xA053,
        PKTSkillDamageAbnormalMoveNotify = 0x815D,
        PKTSkillDamageNotify = 0x514B,
        PKTSkillStageNotify = 0x112F,
        PKTSkillStartNotify = 0xA0BA,
        PKTStatChangeOriginNotify = 0x688,
        PKTStatusEffectAddNotify = 0x343D,
        PKTStatusEffectRemoveNotify = 0x38EF,
        PKTTriggerBossBattleStatus = 0x93AC,
        PKTTriggerStartNotify = 0xD2BC,
    }
}
