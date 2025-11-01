using System.Collections.Generic;
using Terraria;

namespace OSRSPotions.Content
{
    public abstract class OSRSBuffPotion : OSRSPotion
    {
        public virtual List<int> WeakerIncompatibleBuffs()
        {
            return [];
        }
        public virtual List<int> StrongerIncompatibleBuffs()
        {
            return [];
        }

        public override bool ConsumeItem(Player player)
        {
            if (StrongerIncompatibleBuffs().Exists(player.HasBuff))
            {
                player.ClearBuff(Item.buffType);
                return false;
            }

            foreach (int weakerBuffId in WeakerIncompatibleBuffs())
            {
                player.ClearBuff(weakerBuffId);
            }

            return true;
        }
    }
}
