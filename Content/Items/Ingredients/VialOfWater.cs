using Terraria;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Items.Ingredients
{
    internal class VialOfWater : ModItem
    {
        public override void SetDefaults()
        {
            Item.maxStack = Item.CommonMaxStack;
            Item.ResearchUnlockCount = 25;
            Item.value = Item.buyPrice(0, 0, 0, 10);
        }
    }
}
