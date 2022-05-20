using System;
namespace LostArkLogger
{
    public enum OpCodes_steam : UInt16
    {
        PKTCounterAttackNotify = 0xEBC,
        PKTInitEnv = 0x6813,
        PKTInitPC = 0xC328,
        PKTNewNpc = 0xC7AC,
        PKTNewNpcSummon = 0xA279,
        PKTNewPC = 0x416B,
        PKTNewProjectile = 0x8D3A,
        PKTSkillDamageAbnormalMoveNotify = 0x790,
        PKTSkillDamageNotify = 0x2580,
        PKTStatChangeOriginNotify = 0x9FC3,
        PKTStatusEffectAddNotify = 0x1CC2,
    }
}
