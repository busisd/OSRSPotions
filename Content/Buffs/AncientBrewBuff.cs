using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Buffs
{
    internal class AncientBrewBuff : ModBuff
    {
        public static readonly float AncientBrewBonus = .1f;
        public static readonly int AncientBrewManaBonus = 40;

        public override LocalizedText Description => base.Description.WithFormatArgs(AncientBrewBonus * 100, AncientBrewManaBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Magic) += AncientBrewBonus;
            player.statManaMax2 += AncientBrewManaBonus;
        }
    }
}
