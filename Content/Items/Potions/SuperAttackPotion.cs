using Microsoft.Xna.Framework.Graphics;
using OSRSPotions.Content.Buffs;
using OSRSPotions.Content.Items.Herbs;
using OSRSPotions.Content.Items.Ingredients;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Items.Potions
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

            Item.value = Item.buyPrice(0, 0, 10, 0);
        }

        public override List<int> WeakerIncompatibleBuffs()
        {
            return [ModContent.BuffType<AttackPotionBuff>()];
        }

        public override List<int> StrongerIncompatibleBuffs()
        {
            return [ModContent.BuffType<SuperCombatPotionBuff>()];
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(3);
            recipe.AddIngredient<VialOfWater>();
            recipe.AddIngredient<Snapdragon>();
            recipe.AddIngredient<EyeOfNewt>();
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }

    }
}
