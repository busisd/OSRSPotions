using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Buffs
{
    internal class RangingPotionBuff : ModBuff
    {
        public static readonly float RangingPotionBonus = .05f;

        public override LocalizedText Description => base.Description.WithFormatArgs(RangingPotionBonus * 100);

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Ranged) += RangingPotionBonus;
        }
    }
}
