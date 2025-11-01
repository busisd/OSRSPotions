using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Buffs
{
    internal class DefencePotionBuff : ModBuff
    {
        public static readonly int DefencePotionBonus = 8;

        public override LocalizedText Description => base.Description.WithFormatArgs(DefencePotionBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += DefencePotionBonus;
        }
    }
}
