using OSRSPotions.Content.Items.Herbs;
using OSRSPotions.Content.Items.Seeds;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Tiles
{
    public class GuamPlant : OSRSHerbPlant
    {
        public override int HerbItemType() => ModContent.ItemType<GuamLeaf>();
        public override int HerbSeedType() => ModContent.ItemType<GuamSeed>();
    }
}
