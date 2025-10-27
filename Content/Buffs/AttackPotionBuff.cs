using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace OSRSPotions.Content.Buffs
{
    // TODO: Better buff sprite?
    internal class AttackPotionBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            // TODO: Should I make damage-class specific potions? (Attack could be melee speed and/or crit, str is damage)
            player.GetCritChance(DamageClass.Generic) += 5;
        }
    }
}
