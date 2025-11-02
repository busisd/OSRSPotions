using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;
using Terraria.ModLoader;

namespace OSRSPotions.Content.EmoteBubbles
{
    internal class GuthixianDruidEmote : ModEmoteBubble
    {
        private static readonly int EmoteWidth = 34;
        private static readonly int EmoteHeight = 28;

        public override void SetStaticDefaults()
        {
            // Add NPC emotes to "Town" category.
            AddToCategory(EmoteID.Category.Town);
        }

        //// You should decide the frame rectangle yourself by these two methods.
        public override Rectangle? GetFrame()
        {
            return new Rectangle(EmoteBubble.frame * EmoteWidth, 0, EmoteWidth, EmoteHeight);
        }

        //// Do note that you should never use EmoteBubble instance as the GetFrame() method above
        //// in "Emote Menu Methods" (methods with -InEmoteMenu suffix).
        //// Because in that case the value of EmoteBubble is always null.
        public override Rectangle? GetFrameInEmoteMenu(int frame, int frameCounter)
        {
            return new Rectangle(frame * EmoteWidth, 0, EmoteWidth, EmoteHeight);
        }
    }
}
