using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Buffs
{
    internal class StrengthPotionBuff : ModBuff
    {
        public static readonly float StrengthPotionBonus = .05f;

        public override LocalizedText Description => base.Description.WithFormatArgs(StrengthPotionBonus * 100);

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Melee) += StrengthPotionBonus;
        }
    }
}
