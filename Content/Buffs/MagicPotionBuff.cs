using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Buffs
{
    internal class MagicPotionBuff : ModBuff
    {
        public static readonly float MagicPotionBonus = .05f;

        public override LocalizedText Description => base.Description.WithFormatArgs(MagicPotionBonus * 100);

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Magic) += MagicPotionBonus;
        }
    }
}
