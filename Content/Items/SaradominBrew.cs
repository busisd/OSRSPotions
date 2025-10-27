using Microsoft.Xna.Framework.Graphics;
using OSRSPotions.Content.Buffs;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Items
{
    // See: https://github.com/tModLoader/tModLoader/blob/b8a5a286c8bcf872e7d836f3f0238f97331d17c9/ExampleMod/Content/Items/CustomItemDrawingShowcase.cs#L16
    public class SaradominBrew : OSRSPotion
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

            Item.healLife = 150;
            Item.potion = true;
        }

        public override void OnConsumeItem(Player player)
        {
            base.OnConsumeItem(player);
            // TODO: Custom buff? Should share super defence buff probably
            player.AddBuff(BuffID.Endurance, 60 * 60 * 6);
        }
    }
}
