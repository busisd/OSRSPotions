using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Buffs
{
    internal class SuperStrengthPotionBuff : ModBuff
    {
        public static readonly float SuperStrengthPotionBonus = .1f;

        public override LocalizedText Description => base.Description.WithFormatArgs(SuperStrengthPotionBonus * 100);

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Melee) += SuperStrengthPotionBonus;
        }
    }
}
