using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Buffs
{
    internal class SuperRangingPotionBuff : ModBuff
    {
        public static readonly float SuperRangingPotionBonus = .1f;
        public static readonly float SuperRangingPotionCritBonus = 5;

        public override LocalizedText Description => base.Description.WithFormatArgs(SuperRangingPotionBonus * 100, SuperRangingPotionCritBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Ranged) += SuperRangingPotionBonus;
            player.GetCritChance(DamageClass.Ranged) += SuperRangingPotionCritBonus;
        }
    }
}
