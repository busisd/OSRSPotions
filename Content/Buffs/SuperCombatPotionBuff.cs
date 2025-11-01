using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Buffs
{
    internal class SuperCombatPotionBuff : ModBuff
    {
        public override LocalizedText Description => base.Description.WithFormatArgs(SuperAttackPotionBuff.SuperAttackPotionBonus * 100,
            SuperStrengthPotionBuff.SuperStrengthPotionBonus * 100,
            SuperDefencePotionBuff.SuperDefencePotionBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetAttackSpeed(DamageClass.Melee) += SuperAttackPotionBuff.SuperAttackPotionBonus;
            player.GetDamage(DamageClass.Melee) += SuperStrengthPotionBuff.SuperStrengthPotionBonus;
            player.statDefense += SuperDefencePotionBuff.SuperDefencePotionBonus;
        }
    }
}
