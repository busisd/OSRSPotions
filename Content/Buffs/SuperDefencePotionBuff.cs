using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Buffs
{
    internal class SuperDefencePotionBuff : ModBuff
    {
        public static readonly int SuperDefencePotionBonus = 16;

        public override LocalizedText Description => base.Description.WithFormatArgs(SuperDefencePotionBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += SuperDefencePotionBonus;
        }
    }
}
