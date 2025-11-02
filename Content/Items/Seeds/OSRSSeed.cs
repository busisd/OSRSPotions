using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Items.Seeds
{
    public abstract class OSRSSeed : ModItem
    {
        public static readonly int SPRITE_W = 30;
        public static readonly int SPRITE_H = 25;
        public static readonly Rectangle SPRITE_RECT_STACK_1 = new Rectangle(SPRITE_W * 0, 0, SPRITE_W, SPRITE_H);
        public static readonly Rectangle SPRITE_RECT_STACK_2 = new Rectangle(SPRITE_W * 1, 0, SPRITE_W, SPRITE_H);
        public static readonly Rectangle SPRITE_RECT_STACK_3 = new Rectangle(SPRITE_W * 2, 0, SPRITE_W, SPRITE_H);
        public static readonly Rectangle SPRITE_RECT_STACK_4 = new Rectangle(SPRITE_W * 3, 0, SPRITE_W, SPRITE_H);
        public static readonly Rectangle SPRITE_RECT_STACK_5 = new Rectangle(SPRITE_W * 4, 0, SPRITE_W, SPRITE_H);
        public static Rectangle GetRectForStackSize(int stackSize)
        {
            switch (stackSize)
            {
                case 1:
                    return SPRITE_RECT_STACK_1;
                case 2:
                    return SPRITE_RECT_STACK_2;
                case 3:
                    return SPRITE_RECT_STACK_3;
                case 4:
                    return SPRITE_RECT_STACK_4;
                case 5:
                default:
                    return SPRITE_RECT_STACK_5;
            }
        }

        // The stack texture is used for rendering a dynamic sprite in the inventory and world.
        // The default texture is used to get the correct sprite dimensions.
        public abstract Asset<Texture2D> StackTexture();

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            spriteBatch.Draw(StackTexture().Value, position, GetRectForStackSize(Item.stack), drawColor, 0, origin, scale, SpriteEffects.None, 0);
            return false;
        }

        // See: https://github.com/tModLoader/tModLoader/blob/b8a5a286c8bcf872e7d836f3f0238f97331d17c9/ExampleMod/Content/Items/CustomItemDrawingShowcase.cs#L114
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Rectangle drawRect = GetRectForStackSize(Item.stack);
            Vector2 drawOrigin = drawRect.Size() / 2f;
            // Items in the world are drawn centered horizontally sitting at the bottom of the item hitbox, not in the center. 
            Vector2 drawPosition = Item.Bottom - Main.screenPosition - new Vector2(0, drawOrigin.Y);

            spriteBatch.Draw(StackTexture().Value, drawPosition, drawRect, lightColor, 0, drawOrigin, scale, SpriteEffects.None, 0);

            return false;
        }

        public override void SetDefaults()
        {
            Item.maxStack = Item.CommonMaxStack;
            Item.ResearchUnlockCount = 25;
        }

        public override void SetStaticDefaults()
        {
            ItemID.Sets.DisableAutomaticPlaceableDrop[Type] = true;
        }
    }
}
