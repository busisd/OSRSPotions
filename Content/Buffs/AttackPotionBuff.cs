using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Buffs
{
    internal class AttackPotionBuff : ModBuff
    {
        public static readonly float AttackPotionBonus = .08f;

        public override LocalizedText Description => base.Description.WithFormatArgs(AttackPotionBonus * 100);

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetAttackSpeed(DamageClass.Melee) += AttackPotionBonus;
        }
    }
}
