using Microsoft.Xna.Framework.Graphics;
using OSRSPotions.Content.Tiles;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Items.Seeds
{
    public class GuamSeed : OSRSSeed
    {
        private static Asset<Texture2D> stackTexture;
        public override void Load()
        {
            base.Load();
            stackTexture = ModContent.Request<Texture2D>(Texture + "Stack");
        }
        public override Asset<Texture2D> StackTexture() => stackTexture;

        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.DefaultToPlaceableTile(ModContent.TileType<GuamPlant>());
            Item.value = Item.buyPrice(0, 0, 10, 0);
        }

    }
}
