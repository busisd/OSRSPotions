using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Buffs
{
    internal class SuperAttackPotionBuff : ModBuff
    {
        public static readonly float SuperAttackPotionBonus = .16f;

        public override LocalizedText Description => base.Description.WithFormatArgs(SuperAttackPotionBonus * 100);

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetAttackSpeed(DamageClass.Melee) += SuperAttackPotionBonus;
        }
    }
}
