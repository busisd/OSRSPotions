using Microsoft.Xna.Framework.Graphics;
using OSRSPotions.Content.Buffs;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Items
{
    // See: https://github.com/tModLoader/tModLoader/blob/b8a5a286c8bcf872e7d836f3f0238f97331d17c9/ExampleMod/Content/Items/CustomItemDrawingShowcase.cs#L16
    public class SuperAttackPotion : OSRSBuffPotion
    {
        private static Asset<Texture2D> dosesTexture;
        public override void Load()
        {
            base.Load();
            dosesTexture = ModContent.Request<Texture2D>(Texture + "Doses");
        }
        public override Asset<Texture2D> DosesTexture() => dosesTexture;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(SuperAttackPotionBuff.SuperAttackPotionBonus * 100);

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.buffType = ModContent.BuffType<SuperAttackPotionBuff>();
            Item.buffTime = 60 * 60 * 6;
        }

        public override List<int> WeakerIncompatibleBuffs()
        {
            return [ModContent.BuffType<AttackPotionBuff>()];
        }

        public override List<int> StrongerIncompatibleBuffs()
        {
            return [ModContent.BuffType<SuperCombatPotionBuff>()];
        }

    }
}
