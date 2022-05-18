using System;
namespace LostArkLogger
{
    [Flags] public enum DamageModifierFlags // 0b**FBKD*C with F: front attack, B: Back attack, K: bleed crit (dots ?), D: bleed not crit (dots ?), C: crit
    {
        None = 0,
        SkillCrit = 1,
        UnkModifier1 = 2,
        DotNoCrit = 4,
        DotCrit = 8,
        BackAttack = 0x10,
        FrontAttack = 0x20,
        UnkModifier2 = 0x40,
        UnkModifier3 = 0x80
    }
}
