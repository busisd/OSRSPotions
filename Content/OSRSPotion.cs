using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OSRSPotions.Content
{
    // See: https://github.com/tModLoader/tModLoader/blob/b8a5a286c8bcf872e7d836f3f0238f97331d17c9/ExampleMod/Content/Items/CustomItemDrawingShowcase.cs#L16
    public abstract class OSRSPotion : ModItem
    {
        public static readonly int SPRITE_W = 21;
        public static readonly int SPRITE_H = 30;
        public static readonly Rectangle SPRITE_RECT_DOSE_1 = new Rectangle(SPRITE_W * 0, 0, SPRITE_W, SPRITE_H);
        public static readonly Rectangle SPRITE_RECT_DOSE_2 = new Rectangle(SPRITE_W * 1, 0, SPRITE_W, SPRITE_H);
        public static readonly Rectangle SPRITE_RECT_DOSE_3 = new Rectangle(SPRITE_W * 2, 0, SPRITE_W, SPRITE_H);
        public static readonly Rectangle SPRITE_RECT_DOSE_4 = new Rectangle(SPRITE_W * 3, 0, SPRITE_W, SPRITE_H);

        public static Rectangle GetRectForStackSize(int stackSize)
        {
            switch (stackSize)
            {
                case 1:
                    return SPRITE_RECT_DOSE_1;
                case 2:
                    return SPRITE_RECT_DOSE_2;
                case 3:
                    return SPRITE_RECT_DOSE_3;
                case 4:
                default:
                    return SPRITE_RECT_DOSE_4;
            }
        }

        // The doses texture is used for rendering a dynamic sprite in the inventory and world.
        // The default texture is used to get the correct sprite dimensions and during the drinking animation.
        public abstract Asset<Texture2D> DosesTexture();

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            spriteBatch.Draw(DosesTexture().Value, position, GetRectForStackSize(Item.stack), drawColor, 0, origin, scale, SpriteEffects.None, 0);
            return false;
        }

        // See: https://github.com/tModLoader/tModLoader/blob/b8a5a286c8bcf872e7d836f3f0238f97331d17c9/ExampleMod/Content/Items/CustomItemDrawingShowcase.cs#L114
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Rectangle drawRect = GetRectForStackSize(Item.stack);
            Vector2 drawOrigin = drawRect.Size() / 2f;
            // Items in the world are drawn centered horizontally sitting at the bottom of the item hitbox, not in the center. 
            Vector2 drawPosition = Item.Bottom - Main.screenPosition - new Vector2(0, drawOrigin.Y);

            spriteBatch.Draw(DosesTexture().Value, drawPosition, drawRect, lightColor, 0, drawOrigin, scale, SpriteEffects.None, 0);

            return false;
        }

        // The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.OSRSPotions.hjson' file.
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 20;

            // Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
            ItemID.Sets.DrinkParticleColors[Type] = [
                new Color(240, 240, 240),
                new Color(200, 200, 200),
                new Color(140, 140, 140)
            ];
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = OSRSPotions.DRINK_SFX;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(gold: 1);
        }

        // TODO: Better recipe
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(3);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.Register();
        }
    }
}
