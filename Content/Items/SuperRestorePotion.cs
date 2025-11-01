using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Items
{
    // See: https://github.com/tModLoader/tModLoader/blob/b8a5a286c8bcf872e7d836f3f0238f97331d17c9/ExampleMod/Content/Items/CustomItemDrawingShowcase.cs#L16
    public class SuperRestorePotion : OSRSPotion
    {
        private static Asset<Texture2D> dosesTexture;
        public override void Load()
        {
            base.Load();
            dosesTexture = ModContent.Request<Texture2D>(Texture + "Doses");
        }
        public override Asset<Texture2D> DosesTexture() => dosesTexture;

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.healMana = 250;
            Item.potion = true;
        }

        public override void OnConsumeItem(Player player)
        {
            base.OnConsumeItem(player);
            player.ClearBuff(BuffID.Slow);
            player.ClearBuff(BuffID.Weak);
            player.ClearBuff(BuffID.BrokenArmor);
            player.ClearBuff(BuffID.Ichor);
            player.ClearBuff(BuffID.Chilled);
            player.ClearBuff(BuffID.Blackout);
        }
    }
}
