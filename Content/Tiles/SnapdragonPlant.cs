using OSRSPotions.Content.Items.Herbs;
using OSRSPotions.Content.Items.Seeds;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Tiles
{
    public class SnapdragonPlant : OSRSHerbPlant
    {
        public override int HerbItemType() => ModContent.ItemType<Snapdragon>();
        public override int HerbSeedType() => ModContent.ItemType<SnapdragonSeed>();
    }
}
